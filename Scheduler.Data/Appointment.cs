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
        public string ServiceRequest { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public DateTime Duration { get; set; } 


        [Required, ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [Required, ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

    }
}
