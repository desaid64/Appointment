using AutoMapper;
using AppointmentService.Models;
using AppointmentService.Models.Dto;

namespace AppointmentService.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Source -> Target
            CreateMap<Appointment, AppointmentReadDto>();
            CreateMap<AppointmentCreateDto, Appointment>();
        }
    }
}