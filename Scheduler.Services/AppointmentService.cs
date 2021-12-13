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
                    ClientId = model.ClientId,
                    EmployeeId = model.EmployeeId,
                    Time = model.Time,
                    Duration = model.Duration,
                    ServiceRequest = model.ServiceRequest
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
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
                        ClientId = e.ClientId,
                        Client = new ClientList
                        {
                            Name = e.Client.FullName(),
                            Id = e.Client.Id
                        },
                        EmployeeId = e.EmployeeId,
                        Employee = new EmployeeList
                        {
                            Name = e.Employee.FullName(),
                            Id = e.Employee.Id
                        },
                        Time = e.Time
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
                        ClientId = entity.ClientId,
                        Client = new ClientList
                        {
                            Name = entity.Client.FullName(),
                            Id = entity.Client.Id
                        },
                        EmployeeId = entity.EmployeeId,
                        Employee = new EmployeeList
                        {
                            Name = entity.Employee.FullName(),
                            Id = entity.Employee.Id
                        },
                        Time = entity.Time
                    };
            }
        }

        public bool UpdateAppointment(AppointmentDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Appointments
                    .Single(e => e.Id == model.Id);

                entity.ClientId = model.ClientId;
                entity.EmployeeId = model.EmployeeId;
                entity.Time = model.Time;

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