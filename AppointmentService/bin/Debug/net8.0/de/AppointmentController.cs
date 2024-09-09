using AppointmentService.Repository;
using Microsoft.AspNetCore.Mvc;
using AppointmentService.Models.Dto;
using AppointmentService.Models;
using AutoMapper;


namespace AppointmentService.Controller
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepo repo;
        private readonly IMapper mapper;

        public AppointmentController(IAppointmentRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        // GET /appointment/getAppByID/{aid}
        [HttpGet("getAppByID/{aid}", Name = "GetAppByID")]
        public ActionResult<AppointmentReadDto> GetAppByID(int aid)
        {
            var appointment = repo.GetAppointmentByAppId(aid);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<AppointmentReadDto>(appointment));
        }

        // GET /appointment/getAppsByUserId/{uid}
        [HttpGet("getAppsByUserId/{uid}")]
        public ActionResult<IEnumerable<AppointmentReadDto>> GetAppByUserID(int uid)
        {
            var appointments = repo.GetAppointmentByUserId(uid);

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<AppointmentReadDto>>(appointments));
        }

        // GET /appointment/all
        [HttpGet("all")]
        public ActionResult<IEnumerable<AppointmentReadDto>> GetAllAppointments()
        {
            var appointments = repo.GetAllAppointments();

            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<AppointmentReadDto>>(appointments));
        }

        // POST /appointment
        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateAppointment(AppointmentCreateDto appCreateDto)
        {
            var appointment = mapper.Map<Appointment>(appCreateDto);
            repo.CreateAppointment(appointment);
            repo.SaveChanges();
            var appReadDto = mapper.Map<AppointmentReadDto>(appointment);
            return CreatedAtRoute(nameof(GetAppByID), new { Aid = appReadDto.Aid }, appReadDto);
        }

        // PUT /appointment/{aid}
        [HttpPut("{aid}")]
        public ActionResult<AppointmentReadDto> EditAppointment(int aid, AppointmentCreateDto appCreateDto)
        {
            var appointment = mapper.Map<Appointment>(appCreateDto);
            bool updated = repo.EditAppointment(aid, appointment);

            if (!updated)
            {
                return NotFound();
            }
            appointment.Aid = aid;
            return Ok(mapper.Map<AppointmentReadDto>(appointment));
        }

        // DELETE /appointment/{aid}
        [HttpDelete("{aid}")]
        public IActionResult DeleteAppointment(int aid)
        {
            bool deleted = repo.DeleteAppointment(aid);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        // PUT /appointment/status/{aid}/{st}
        [HttpPut("status/{aid}/{st}")]
        public IActionResult UpdateStatus(int aid, int st)
        {
            string status = "Rejected";
            if (st == 1)
            {
                status = "Accepted";
            }
            bool updated = repo.UpdateStatus(aid, status);

            if (!updated)
            {
                return NotFound();
            }
            return NoContent(); ;
        }
    }
}