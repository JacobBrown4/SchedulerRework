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
       
        public string EmployeeOccupation { get; set; }

        public TimeSpan Duration { get; set; }

        public string FullName() => $"{FirstName} {LastName}";
    }
}
