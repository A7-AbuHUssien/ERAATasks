namespace DoctorManagementSystem.Models;

public class DoctorIndexViewModel
{
    public IEnumerable<Doctor> Doctors { get; set; } = Enumerable.Empty<Doctor>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }

    public string? SearchName { get; set; }
    public string? Specialization { get; set; }
}
