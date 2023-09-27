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

        public AddressController(IAddressEditAppService addressEditAppService)
        {
            _addressEditAppService = addressEditAppService;
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
            catch (DbUpdateConcurrencyException ex)
            {
                // Trate a exceção de concorrência aqui
                // Exemplo: Registrar detalhes, enviar uma resposta de erro personalizada, etc.
                return StatusCode(409, "Concorrência detectada: A entidade foi modificada por outro usuário.");
            }
            catch (ArgumentValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
