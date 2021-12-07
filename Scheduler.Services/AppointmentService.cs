using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;
        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }


    }
}
