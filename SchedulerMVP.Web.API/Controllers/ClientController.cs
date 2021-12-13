using Microsoft.AspNet.Identity;
using Scheduler.Models.ClientModels;
using Scheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchedulerMVP.Web.API.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var clientService = new ClientService(userId);
            return clientService;
        }
        public IHttpActionResult Get()
        {
            ClientService clientService = CreateClientService();
            var clients = clientService.GetClients();
            return Ok(clients);
        }
        public IHttpActionResult Post(ClientCreate client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClientService();

            if (!service.CreateClient(client))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ClientService clientService = CreateClientService();
            var client = clientService.GetClientById(id);
            return Ok(client);
        }

        public IHttpActionResult Put(ClientEdit client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateClientService();

            if (!service.UpdateClient(client))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateClientService();

            if (!service.DeleteClient(id))
                return InternalServerError();
            return Ok();
        }
    }
}