using ChefDigital.Entities.Entities;
using ChefDigitalAPI.Application.Address.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChefDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /*TODO
         * Editar
         * listar todos
         * listar por id cliente
         * desativar
         */

        private readonly IAddressEditAppService _addressEditAppService;
        private readonly IAddressListAppService _addressListAppService;
        private readonly IAddressListByIdClientAppService _addressListByIdClient;
        private readonly IAddressDisableAppService _addressDisableAddresAppService;

        public AddressController(IAddressEditAppService addressEditAppService,
                                    IAddressListAppService addressListAppService,
                                    IAddressListByIdClientAppService addressListByIdClient,
                                    IAddressDisableAppService addressDisableAddresAppService)
        {
            _addressEditAppService = addressEditAppService;
            _addressListAppService = addressListAppService;
            _addressListByIdClient = addressListByIdClient;
            _addressDisableAddresAppService = addressDisableAddresAppService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Entities.Entities.Address newAddress)
        {
            try
            {
                Entities.Entities.Address addressEdit = new Entities.Entities.Address();
                addressEdit = await _addressEditAppService.Edit(id, newAddress);

                return Ok(addressEdit);
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            try
            {
                List<Entities.Entities.Address> resultados = await _addressListAppService.List();
                return Ok(resultados);
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> ListByIdClient(Guid idClient)
        {
            try
            {
                List<Entities.Entities.Address> resultados = await _addressListByIdClient.List(idClient);
                return Ok(resultados);
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableAddress(Guid id)
        {
            try
            {
                var address = await _addressDisableAddresAppService.Disable(id);
                return Ok(address);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
