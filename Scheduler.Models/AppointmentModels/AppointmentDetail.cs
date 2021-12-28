using Scheduler.Models.ClientModels;
using Scheduler.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.AppointmentModels
{
    public class AppointmentDetail
    {
        public int Id { get; set; }
        public string ServiceRequested { get; set; }
        public string AppointmentInfo { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }

    }
}
