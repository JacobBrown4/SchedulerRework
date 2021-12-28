using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
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


        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set;}

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
