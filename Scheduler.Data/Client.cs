using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Data
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public string FullName() => $"{FirstName} {LastName}";


    }
}
