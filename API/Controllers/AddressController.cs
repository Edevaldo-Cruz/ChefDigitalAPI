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
        public async Task<IActionResult> Edit(Guid id, [FromBody] AddressEditDTO newAddress)
        {
            var addressEdit = await _addressEditAppService.EditAsync(id, newAddress);
            if (addressEdit.HasNotifications)
                return BadRequest(addressEdit.Notitycoes);

            return Ok(addressEdit);
        }


        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            List<Entities.Entities.Address> resultados = await _addressListAppService.ListAsync();
            return Ok(resultados);
        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> ListByIdClient(Guid idClient)
        {
            List<Entities.Entities.Address> list = await _addressListByIdClient.ListAsync(idClient);
            return Ok(list);
        }

        [HttpPut("disable/{id}")]
        public async Task<IActionResult> DisableAddress(Guid id)
        {
                var address = await _addressDisableAddresAppService.DisableAsync(id);
                return Ok(address);
            
        }

    }
}
