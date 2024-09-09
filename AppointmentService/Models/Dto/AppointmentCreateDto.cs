

namespace AppointmentService.Models.Dto
{
    public class AppointmentCreateDto
    {
        public required int Uid { get; set; }

        public required string Status { get; set; }

        public required DateTimeOffset CreatedDate { get; set; }
    }
}