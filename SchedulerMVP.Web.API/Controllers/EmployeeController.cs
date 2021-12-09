using Microsoft.AspNet.Identity;
using Scheduler.Data;
using Scheduler.Models.EmployeeModels;
using Scheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SchedulerMVP.Web.API.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {

        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }
        public IHttpActionResult Get()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = employeeService.GetEmployees();
            return Ok(employees);
        }
        public IHttpActionResult Post(EmployeeCreate employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployeeService();

            if (!service.CreateEmployee(employee))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            EmployeeService clientService = CreateEmployeeService();
            var employee = clientService.GetEmployeeById(id);
            return Ok(employee);
        }
        public IHttpActionResult Put(EmployeeEdit employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEmployeeService();

            if (!service.UpdateEmployee(employee))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEmployeeService();

            if (!service.DeleteEmployee(id))
                return InternalServerError();
            return Ok();
        }
    }
}