using System.ComponentModel.DataAnnotations;

namespace DoctorManagementSystem.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required] public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    [Required] [StringLength(100)] 
    public string PatientName { get; set; }

    [Required]
    public DateTime AppointmentDateTime { get; set; }
}
