using DoctorManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagementSystem.Controllers;

public class AppointmentsController : Controller
{
    private readonly ApplicationDbContext _context;
    public AppointmentsController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        var appointments = await _context.Appointments
            .Include(a => a.Doctor)
            .OrderByDescending(a => a.AppointmentDateTime)
            .ToListAsync();

        return View(appointments);
    }
}
