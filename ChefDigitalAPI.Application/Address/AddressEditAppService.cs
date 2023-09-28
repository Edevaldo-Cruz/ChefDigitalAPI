using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.DTO.Address;
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

        public async Task<ChefDigital.Entities.Entities.Address> EditAsync(Guid id, AddressEditDTO address)
        {
           var resultado = await _addressEditService.EditAsync(id, address.ToAddress());
            return resultado;
        }
    }
}
