using System.ComponentModel.DataAnnotations;

namespace DoctorManagementSystem.Models;

public class Doctor
{
    public int Id { get; set; }

    [Required] 
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required] 
    public string Specialization { get; set; }

    
    public string? PhotoPath { get; set; }

    public string FullName => $"{FirstName} {LastName}";
    public ICollection<Appointment>? Appointments { get; set; }
}
