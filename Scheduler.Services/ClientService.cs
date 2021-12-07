using Scheduler.Data;
using Scheduler.Models.ClientModels;
using SchedulerMVP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Services
{
    public class ClientService
    {
        
       /*
        
        private readonly Guid _userId;
        public ClientService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                ctx.SaveChanges();
                int iD = ctx.Clients.AsEnumerable().Last().Id;
                int savedObjects = 0;
                if (model.Employees != null)
                {
                    foreach (int employee in model.Employees)
                    {
                        Appointment appointment = new Appointment
                        {
                            EmployeeId = employee,
                            ClientId = iD,
                        };
                        ctx.Appointments.Add(appointment);
                        ++savedObjects;
                    };
                }
                return ctx.SaveChanges() == savedObjects;
            }
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Clients.AsEnumerable()
                        .Select(
                        e =>
                            new ClientListItem
                            {
                                Id = e.Id,
                                Name = e.FullName()
                            }).ToArray();
                return query;
            }
        }
        public ClientDetail GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Clients
                    .Single(e => e.Id == id);
                return
                    new ClientDetail
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Employees = entity.Appointments.Select(c => new EmployeeListItem
                        {
                            Id = c.Id,
                            Name = c.Employee.Name
                        }).ToList()
                    };
            }
        }
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Clients
                    .Single(e => e.Id == model.Id);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.Id == clientId);
                ctx.Clients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        */
    }
}
