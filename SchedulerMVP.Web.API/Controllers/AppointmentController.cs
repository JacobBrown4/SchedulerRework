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
    [RoutePrefix("api/appointment")]
    public class AppointmentController : ApiController
    {
        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var appointmentService = new AppointmentService(userId);
            return appointmentService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointments = appointmentService.GetAppointments();
            return Ok(appointments);
        }
        
        [HttpPost]
        public IHttpActionResult Post(AppointmentCreate appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAppointmentService();
            if (!service.CreateAppointment(appointment))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        [Route("NewClient")]
        // It's not often you'd book an appointment with an entirely new employee. Like usually you'd want some verification process for employee's or add them later. But it would make sense to add a new client to the system and book their appointment at once. Here's an end point to do both at once.
        public IHttpActionResult PostWithClient(AppointmentClientCreate appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAppointmentService();
            if (!service.CreateAppointmentWithClient(appointment))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        [Route("{id}")]

        public IHttpActionResult Get(int id)
        {
            AppointmentService appointmentService = CreateAppointmentService();
            var appointment = appointmentService.GetAppointmentByID(id);
            return Ok(appointment);
        }
        [HttpPut]
        public IHttpActionResult Put(AppointmentEdit appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAppointmentService();

            if (!service.UpdateAppointment(appointment))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAppointmentService();

            if (!service.DeleteAppointment(id))
                return InternalServerError();
            return Ok();
        }

    }
}