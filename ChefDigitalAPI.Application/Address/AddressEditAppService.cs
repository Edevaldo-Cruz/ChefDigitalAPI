using ChefDigital.Domain.Interfaces.Address;
using ChefDigitalAPI.Application.Address.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address
{
    public class AddressEditAppService : IAddressEditAppService
    {
        private readonly IAddressEditService _addressEditService;

        public AddressEditAppService(IAddressEditService addressEditService)
        {
            _addressEditService = addressEditService;
        }

        public async Task<ChefDigital.Entities.Entities.Address> Edit(Guid id, ChefDigital.Entities.Entities.Address address)
        {
           var resultado = await _addressEditService.Edit(id, address);
            return resultado;
        }
    }
}
