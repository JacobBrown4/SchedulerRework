using Scheduler.Data;
using Scheduler.Models.AppointmentModels;
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
                    EmployeeId = model.EmployeeId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
