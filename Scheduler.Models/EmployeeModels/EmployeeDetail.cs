using Scheduler.Models.AppointmentModels;
using Scheduler.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.EmployeeModels
{
    public class EmployeeDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmployeeOccupation { get; set; }

        public List<AppointmentList> Appointments { get; set; }
        public List<ClientList> Clients { get; set; }
    }
}
