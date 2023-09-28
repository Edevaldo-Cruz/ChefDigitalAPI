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

        public AddressController(IAddressEditAppService addressEditAppService, 
                                    IAddressListAppService addressListAppService)
        {
            _addressEditAppService = addressEditAppService;
            _addressListAppService = addressListAppService;
        }

        [HttpPut("api/Edit/{id}")]
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

        [HttpGet("api/List")]
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

    }
}
