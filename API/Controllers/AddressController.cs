using ChefDigital.Entities.DTO.Address;
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
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] AddressEditDTO newAddress)
        {
            var addressEdit = await _addressAppService.EditAsync(id, newAddress);
            if (addressEdit.HasNotifications)
                return BadRequest(addressEdit.Notitycoes);

            return Ok(addressEdit);
        }

        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            List<Entities.Entities.Address> resultados = await _addressAppService.ListAsync();
            return Ok(resultados);
        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> ListByIdClient(Guid idClient)
        {
            List<Entities.Entities.Address> list = await _addressAppService.ListAsync(idClient);

            if (!list.Any())
                return BadRequest("Endereço não encontrado.");

            return Ok(list);
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableAddress(Guid id)
        {
            var address = await _addressAppService.DisableAsync(id);
            return Ok(address);

        }
    }
}
