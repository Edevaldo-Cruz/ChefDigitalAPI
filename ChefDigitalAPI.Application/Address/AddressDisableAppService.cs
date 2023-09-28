using ChefDigital.Domain.Interfaces.Address;
using ChefDigitalAPI.Application.Address.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address
{
    public class AddressDisableAppService : IAddressDisableAppService
    {
        private readonly IAddressDisableService _addressDisableService;

        public AddressDisableAppService(IAddressDisableService addressDisableService)
        {
            _addressDisableService = addressDisableService;
        }

        public async Task<ChefDigital.Entities.Entities.Address> DisableAsync(Guid id)
        {
            return await _addressDisableService.DisableAsync(id);
        }
    }
}
