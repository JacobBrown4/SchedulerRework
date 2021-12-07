using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.AppointmentModels
{
    public class AppointmentCreate
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public DateTime Duration { get; set; }

        public string ServiceRequest { get; set; }

    }
}
