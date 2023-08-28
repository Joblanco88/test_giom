using AspNetCore.Services.Interfaces;
using AspNetCore.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClientsController : ControllerBase
    {
        private IClientRepository _services;

        public ClientsController(IClientRepository services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetClients()
        {
            try
            {
                return await _services.GetClients();
            } 
            catch (Exception ex)
            {
                var message = ex.Message;
                Console.WriteLine(message);
                var clientError = new Client
                {
                    Id = 404,
                    Name = "404",
                    Email = "404",
                    Address = "404",
                    Phone = "404"
                };
                List<Client> clientsError = new List<Client>
                {
                    clientError
                };
                return clientsError;
            }
        }
        [HttpPost]
        public string CreateClient(Client client)
        {
            try
            {
                _services.CreateClient(client);
                return "Cliente criado com sucesso!";
            } 
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        [HttpPut]
        public string UpdateClients(Client client)
        {
            try
            {
                _services.UpdateClients(client);
                return "Cliente atualizado com sucesso!";
            } 
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _services.DeleteClient(id);
                return Ok();
            } 
            catch (Exception ex) 
            {
                return NotFound();
            }
        }
    }
}
