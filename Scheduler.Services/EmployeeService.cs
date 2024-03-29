﻿using DocuSign.eSign.Model;
using Scheduler.Data;
using Scheduler.Models.AppointmentModels;
using Scheduler.Models.ClientModels;
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

        private readonly Guid _userId;
        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Occupation = model.Occupation
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
                        .Employees.AsEnumerable()
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

        public EmployeeDetail GetEmployeeById(int id)
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
                       Name = entity.FullName(),
                       EmployeeOccupation = entity.Occupation,
                       Clients = entity.Appointments.Select(x => x.Client.FullName()).ToList(),
                       Appointments = entity.Appointments.Select(c => new AppointmentList
                       {
                           Id = c.Id,
                           Time = c.Time.ToShortDateString(),
                           ServiceRequested = c.ServiceRequested,
                           Client = c.Client.FullName(),
                           Employee = c.Employee.FullName()

                       }).ToList()
                   };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employees
                    .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Occupation = model.Occupation;

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
