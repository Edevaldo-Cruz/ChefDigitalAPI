using ChefDigital.Entities.DTO.Client;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using ChefDigitalAPI.Application.Client.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChefDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppServiceCreate)
        {
            _clientAppService = clientAppServiceCreate;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] ClientCreateDTO client)
        {
            Entities.Entities.Client newClient = await _clientAppService.Create(client);

            if (newClient.HasNotifications)
                return BadRequest(newClient.Notitycoes);

            return Ok(newClient);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] ClientEditDTO client)
        {
            var clientEdit = await _clientAppService.EditAsync(id, client);

            if (clientEdit.HasNotifications)
                return BadRequest(clientEdit.Notitycoes);

            return Ok(clientEdit);

        }

        [HttpGet("")]
        public async Task<List<ClientListDTO>> List()
        {
            var clients = await _clientAppService.ListAsync();
            return clients;
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableClient(Guid id)
        {
            Client newClient = new Client();
            newClient = await _clientAppService.DisableAsync(id);

            if (newClient.HasNotifications)
                return BadRequest(newClient.Notitycoes);

            return Ok("Cliente desabilitado.");
        }


    }
}
