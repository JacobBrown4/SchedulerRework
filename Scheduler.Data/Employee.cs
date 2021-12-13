using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName {  get; set; }

        [Required]
        public string LastName { get; set; }
       
        [Required]
        public string Occupation { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual string FullName() => $"{FirstName} {LastName}";
    }
}
