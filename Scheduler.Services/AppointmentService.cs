using Scheduler.Data;
using Scheduler.Models.EmployeeModels;
using Scheduler.Models.AppointmentModels;
using Scheduler.Models.ClientModels;
using SchedulerMVP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;
        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity =
                new Appointment()
                {
                    ServiceRequested = model.ServiceRequested,
                    AppointmentInfo = model.AppointmentInfo,
                    Time = model.Time,
                    Duration = model.Duration,
                    Location = model.Location,
                    EmployeeId = model.EmployeeId,
                    ClientId = model.ClientId
                };
            using (var ctx = new ApplicationDbContext())
            {
                if (AppointmentNoOverlap(entity))
                {
                    ctx.Appointments.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
                else return false;
            }
        }
        public bool CreateAppointmentWithClient(AppointmentClientCreate model)
        {
            // So one of our requirements for Appointment is client id. So in order to make an appointment first we'll need to save the Client first.

            //For now I'm going to load up Appointment with what I can, because why not
            var appointment =
                new Appointment()
                {
                    ServiceRequested = model.ServiceRequested,
                    AppointmentInfo = model.AppointmentInfo,
                    Time = model.Time,
                    Duration = model.Duration,
                    Location = model.Location,
                    EmployeeId = model.EmployeeId,
                };
            //Lets go ahead and line up our new client
            var client = new Client()
            {
                FirstName = model.ClientFirstName,
                LastName = model.ClientLastName,
                Email = model.ClientEmail,
                PhoneNumber = model.ClientPhoneNumber
            };
            // Before we save the client lets make sure the appt isn't overlaping
            if (AppointmentNoOverlap(appointment))
            {

                using (var ctx = new ApplicationDbContext())
                {
                    // Add the client
                    ctx.Clients.Add(client);
                    // Save the client, and make sure it did save before we carry on, if it errored we want to stop now.
                    if (ctx.SaveChanges() == 1)
                    {
                        //Lets get the client Id
                        var clientdbObject = ctx.Clients.OrderByDescending(x => x.Id).FirstOrDefault();
                        appointment.ClientId = clientdbObject.Id;
                        ctx.Appointments.Add(appointment);
                        return ctx.SaveChanges() == 1;

                    }
                    return false;
                }
            }
            return false;
        }

        public bool AppointmentNoOverlap(Appointment appointment)
        {
            var newStart = appointment.Time;
            var newEnd = appointment.Time + appointment.Duration;

            using (var ctx = new ApplicationDbContext())
            {
                // Grab employee so we can get it's appts
                var employee = ctx.Employees.Single(x => x.Id == appointment.EmployeeId);

                if (employee != null)
                {
                    // Go through each appt
                    foreach (var apps in employee.Appointments)
                    {
                        var oldStart = apps.Time;
                        var oldEnd = apps.Time + appointment.Duration;
                        //Check for overlaps
                        bool overlap = oldStart < newEnd && newStart < oldEnd;
                        if (overlap)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                return false;
            }
        }
        public IEnumerable<AppointmentList> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appointments.ToArray();
                return query.Select(
                    e =>
                    new AppointmentList
                    {
                        Id = e.Id,
                        Time = e.Time.ToShortDateString(),
                        ServiceRequested = e.ServiceRequested,
                        Client = e.Client.FullName(),
                        Employee = e.Employee.FullName()
                    }).ToArray();
            }
        }

        public AppointmentDetail GetAppointmentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.Id == id);
                return
                    new AppointmentDetail
                    {
                        Id = entity.Id,
                        ServiceRequested = entity.ServiceRequested,
                        AppointmentInfo = entity.AppointmentInfo,
                        Location = entity.Location,
                        StartTime = entity.Time,
                        EndTime = entity.Time + entity.Duration,
                        Duration = entity.Duration,
                        ClientId = entity.ClientId,
                        Client = entity.Client.FullName(),
                        EmployeeId = entity.EmployeeId,
                        Employee = entity.Employee.FullName(),
                    };
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.Id == model.Id);

                entity.ServiceRequested = model.ServiceRequested;
                entity.AppointmentInfo = model.AppointmentInfo;
                entity.Location = model.Location;
                entity.Time = model.Time;
                entity.Duration = model.Duration;
                entity.EmployeeId = model.EmployeeId;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Appointments
                    .Single(e => e.Id == appointmentId);
                ctx.Appointments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}