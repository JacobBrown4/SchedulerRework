using DocuSign.eSign.Model;
using Scheduler.Data;
using Scheduler.Models.EmployeeModels;
using SchedulerMVP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Services
{
    public class EmployeeService
    {
        private readonly Guid _employeeId;
        public EmployeeService(Guid employeeId)
        {
            _employeeId = employeeId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeList> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Select(
                        e =>
                            new EmployeeList
                            {
                                Id = e.Id,
                                Name = e.FullName()
                            }).ToArray();
                return query;
            }
        }

    /*    public EmployeeDetail GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                  .Single(e => e.Id == id);
                return
                     new EmployeeDetail
                     {
                         Id = entity.Id,
                         FullName = entity.FullName,
                         Clients = entity.Appointments.Select(x => new ClientListItem
                         {
                             Id = x.Client.Id,
                             Name = x.Client.FullName()
                         }).ToList()
                     };
            }
        }*/

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employees
                    .Single(e => e.Id == employeeId);
                ctx.Employees.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
