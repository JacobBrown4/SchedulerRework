using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models.AppointmentModels
{
    public class AppointmentClientCreate
    {
        [Required]
        [Display(Name = "Services Requested")]
        public string ServiceRequested { get; set; }
        [Required]
        [Display(Name = "Appointment Info")]
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
        public string ClientFirstName { get; set; }
        [Required]
        public string ClientLastName { get; set; }
        [Required]
        [EmailAddress]
        public string ClientEmail { get; set; }
        [Required]
        [Phone]
        public string ClientPhoneNumber { get; set; }
    }
}
