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

        [HttpPost("/api/create")]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                Client newClient = new Client();
                newClient = await _clientAppServiceCreate.Create(client);
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
                clientUpdade = await _clientUpdateAppService.Update(id, client);
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
            var clients = await _clientListAppService.List();
            return clients;
        }

        [HttpPut("api/disableClient")]
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
