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
        private readonly IClientCreateAppService _clientAppServiceCreate;
        private readonly IClientUpdateAppService _clientUpdateAppService;
        private readonly IClientListAppService _clientListAppService;
        private readonly IClientDisableAppService _clientDisableAppService;

        public ClientController(IClientCreateAppService clientAppServiceCreate,
                                    IClientUpdateAppService clientUpdateAppService,
                                    IClientListAppService clientListAppService,
                                    IClientDisableAppService clientDisableAppService)
        {
            _clientAppServiceCreate = clientAppServiceCreate;
            _clientUpdateAppService = clientUpdateAppService;
            _clientListAppService = clientListAppService;
            _clientDisableAppService = clientDisableAppService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] ClientCreateDTO client)
        {
            Entities.Entities.Client newClient = await _clientAppServiceCreate.Create(client);

            if (newClient.HasNotifications)
                return BadRequest(newClient.Notitycoes);

            return Ok(newClient);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] ClientEditDTO client)
        {
            var clientEdit = await _clientUpdateAppService.EditAsync(id, client);

            if (clientEdit.HasNotifications)
                return BadRequest(clientEdit.Notitycoes);

            return Ok(clientEdit);

        }

        [HttpGet("")]
        public async Task<List<ClientListDTO>> List()
        {
            var clients = await _clientListAppService.ListAsync();
            return clients;
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableClient(Guid id)
        {
            Client newClient = new Client();
            newClient = await _clientDisableAppService.DisableAsync(id);

            if (newClient.HasNotifications)
                return BadRequest(newClient.Notitycoes);

            return Ok("Cliente desabilitado.");
        }


    }
}
