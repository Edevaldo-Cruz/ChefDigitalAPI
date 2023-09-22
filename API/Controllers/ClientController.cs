using AutoMapper;
using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Enums;
using ChefDigitalAPI.Application.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ChefDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [HttpPost("/api/add")]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                Client newClient = new Client();
                newClient = await _clientAppService.Add(client);
                return Ok(newClient);
            }
            catch (ArgumentValidationException ex)
            {
                var innerException = ex.InnerException;
                return BadRequest(innerException);
            }
        }

        [HttpPut("/api/update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Client client)
        {
            try
            {
                Client clientUpdade = new Client();
                clientUpdade = await _clientAppService.Update(id, client);
                return Ok(clientUpdade);
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<List<Client>> List()
        {
            var clients = await _clientAppService.ListClient();
            return clients;
        }

        [HttpPut("api/disableClient")]
        public async Task<IActionResult> DisableClient(Guid id)
        {
            try
            {
                Client newClient = new Client();
                newClient = await _clientAppService.Disable(id);

                return Ok(newClient);

            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
