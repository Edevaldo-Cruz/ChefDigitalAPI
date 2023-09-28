using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigitalAPI.Application.Client.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromBody] ClientDTO client)
        {
            try
            {
                ClientDTO newClient = new ClientDTO();
                newClient = await _clientAppServiceCreate.Create(client);
                return Ok(newClient);
            }
            catch (ArgumentValidationException ex)
            {
                var innerException = ex.InnerException;
                return BadRequest(innerException);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Client client)
        {
            try
            {
                Client clientEdit = new Client();
                clientEdit = await _clientUpdateAppService.Edit(id, client);
                return Ok(clientEdit);
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<List<ClientDTO>> List()
        {
            var clients = await _clientListAppService.List();
            return clients;
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableClient(Guid id)
        {
            try
            {
                Client newClient = new Client();
                newClient = await _clientDisableAppService.Disable(id);

                return Ok(newClient);

            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
