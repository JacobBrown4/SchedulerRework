using Scheduler.Models.ClientModels;
using Scheduler.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.AppointmentModels
{
    public class AppointmentList
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string ServiceRequested { get; set; }
        public string  Client { get; set; }
        public string Employee { get; set; }
    }
}
