using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int Aid { get; set; }

        [Required]
        public int Uid { get; set; }

        public required string Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}