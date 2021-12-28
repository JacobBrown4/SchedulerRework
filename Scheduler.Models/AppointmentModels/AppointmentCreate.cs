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
        [Display(Name ="Services Requested")]
        public string ServiceRequested { get; set; }
        [Required]
        public string AppointmentInfo { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime Time { get; set; }
        [Required]
        //Request style "00:00:00" 
        public TimeSpan Duration { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ClientId { get; set; }

    }
}
