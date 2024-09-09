using AppointmentService.Models;
using AppointmentService.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AppointmentService.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppDbContext context;

        public AppointmentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateAppointment(Appointment app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            context.Appointments.Add(app);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return context.Appointments.ToList();
        }

        public Appointment GetAppointmentByAppId(int aid)
        {
            Appointment? app = context.Appointments.FirstOrDefault(a => a.Aid == aid);
            if (app == null)
            {
                throw new NotImplementedException();
            }
            return app;
        }

        public IEnumerable<Appointment> GetAppointmentByUserId(int uid)
        {
            List<Appointment> apps = context.Appointments.AsEnumerable().Where(a => a.Uid == uid).ToList();
            if (apps == null)
            {
                throw new NotImplementedException();
            }
            return apps;
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public bool DeleteAppointment(int aid)
        {
            return context.Appointments.Where(a => a.Aid == aid).ExecuteDelete() > 0;
        }

        public bool EditAppointment(int aid, Appointment app)
        {

            return context.Appointments.Where(a => a.Aid == aid).ExecuteUpdate(
                setter => setter
                .SetProperty(a => a.Uid, app.Uid)
                .SetProperty(a => a.CreatedDate, app.CreatedDate)
                .SetProperty(a => a.Status, app.Status)
            ) > 0;
        }

        public bool UpdateStatus(int aid, string status)
        {
            return context.Appointments.Where(a => a.Aid == aid).ExecuteUpdate(
                setter => setter
                .SetProperty(a => a.Status, status)
            ) > 0;
        }
    }
}