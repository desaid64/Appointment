using AppointmentService.Models;

namespace AppointmentService.Repository
{
    public interface IAppointmentRepo
    {
        bool SaveChanges();

        IEnumerable<Appointment> GetAllAppointments();

        Appointment GetAppointmentByAppId(int Aid);

        IEnumerable<Appointment> GetAppointmentByUserId(int Uid);

        void CreateAppointment(Appointment app);

        bool DeleteAppointment(int Aid);

        bool EditAppointment(int Aid, Appointment app);

        bool UpdateStatus(int Aid, String status);
    }
}