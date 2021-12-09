using Microsoft.AspNet.Identity;
using Scheduler.Models.AppointmentModels;
using Scheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SchedulerMVP.Web.API.Controllers
{
    [Authorize]
    public class AppointmentController : ApiController
    {
        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var appointmentService = new AppointmentService(userId);
            return appointmentService;
        }

        public IHttpActionResult Get()
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointments = appointmentService.GetAppointments();
            return Ok(appointments);
        }

        public IHttpActionResult Post(AppointmentCreate appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAppointmentService();
            if (!service.CreateAppointment(appointment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointment = appointmentService.GetAppointmentByID(id);
            return Ok(appointment);
        }

        public IHttpActionResult Put(AppointmentDetail appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAppointmentService();

            if (!service.UpdateAppointment(appointment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAppointmentService();

            if (!service.DeleteAppointment(id))
                return InternalServerError();
            return Ok();
        }

    }
}