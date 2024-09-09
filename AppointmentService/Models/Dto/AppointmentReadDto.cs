

namespace AppointmentService.Models.Dto
{
    public class AppointmentReadDto
    {
        public int Aid { get; set; }

        public int Uid { get; set; }

        public required string Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}