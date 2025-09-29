using DoctorManagementSystem.Data;
using DoctorManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementSystem.Controllers;

public class DoctorsController : Controller
{
    private readonly ApplicationDbContext _context;
    public DoctorsController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index(string? searchName, string? specialization, int page = 1, int pageSize = 6)
    {
        var query = _context.Doctors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchName))
            query = query.Where(d => (d.FirstName + " " + d.LastName).Contains(searchName)
                                     || d.FirstName.Contains(searchName) || d.LastName.Contains(searchName));

        if (!string.IsNullOrWhiteSpace(specialization))
            query = query.Where(d => d.Specialization.Contains(specialization));

        var total = await query.CountAsync();
        var doctors = await query
            .OrderBy(d => d.LastName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var vm = new DoctorIndexViewModel
        {
            Doctors = doctors,
            Page = page,
            PageSize = pageSize,
            TotalItems = total,
            SearchName = searchName,
            Specialization = specialization
        };
        return View(vm);
    }

    private static List<TimeSpan> GetAllSlots()
    {
        var slots = new List<TimeSpan>();
        var start = new TimeSpan(8, 0, 0);
        var end = new TimeSpan(16, 30, 0);
        for (var t = start; t <= end; t = t.Add(TimeSpan.FromMinutes(30)))
            slots.Add(t);
        return slots;
    }

    private List<string> GetAvailableSlotsInternal(int doctorId, DateTime date)
    {
        var booked = _context.Appointments
            .Where(a => a.DoctorId == doctorId && a.AppointmentDateTime.Date == date.Date)
            .Select(a => a.AppointmentDateTime.TimeOfDay)
            .ToHashSet();

        return GetAllSlots()
            .Where(s => !booked.Contains(s))
            .Select(s => s.ToString(@"hh\:mm"))
            .ToList();
    }

    [HttpGet]
    public IActionResult GetAvailableSlots(int doctorId, DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
            return Json(new List<string>());

        var slots = GetAvailableSlotsInternal(doctorId, date);
        return Json(slots);
    }

    [HttpPost]
    public async Task<IActionResult> Book([FromBody] BookRequest req)
    {
        if (req == null)
            return BadRequest("Invalid request.");

        if (string.IsNullOrWhiteSpace(req.PatientName) || string.IsNullOrWhiteSpace(req.Time))
            return BadRequest("Please fill in all fields.");

        if (!TimeSpan.TryParse(req.Time, out var ts))
            return BadRequest("Invalid time.");

        var appointmentDateTime = req.Date.Date + ts;

        if (appointmentDateTime.DayOfWeek == DayOfWeek.Friday || appointmentDateTime.DayOfWeek == DayOfWeek.Saturday)
            return BadRequest("Service is available from Sunday to Thursday only.");

        var earliest = new TimeSpan(8, 0, 0);
        var latest = new TimeSpan(16, 30, 0);
        if (ts < earliest || ts > latest)
            return BadRequest("Time is outside working hours (8:00 - 17:00).");

        if (ts.Minutes % 30 != 0)
            return BadRequest("Time must be in 30-minute intervals.");

        var exists = await _context.Appointments
            .AnyAsync(a => a.DoctorId == req.DoctorId && a.AppointmentDateTime == appointmentDateTime);

        if (exists)
            return BadRequest("This appointment has already been booked.");

        var ap = new Appointment
        {
            DoctorId = req.DoctorId,
            PatientName = req.PatientName,
            AppointmentDateTime = appointmentDateTime
        };

        _context.Appointments.Add(ap);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Appointment booked successfully." });
    }

    public class BookRequest
    {
        public int DoctorId { get; set; }
        public string? PatientName { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
    }
}
