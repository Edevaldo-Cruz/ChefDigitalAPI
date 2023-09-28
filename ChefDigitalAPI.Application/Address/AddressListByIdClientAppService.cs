using ChefDigital.Domain.Interfaces.Address;
using ChefDigitalAPI.Application.Address.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address
{
    public class AddressListByIdClientAppService : IAddressListByIdClientAppService
    {
        private readonly IAddressListByIdClientService _addressListByIdClient;

        public AddressListByIdClientAppService(IAddressListByIdClientService addressListByIdClient)
        {
            _addressListByIdClient = addressListByIdClient;
        }

        public async Task<List<ChefDigital.Entities.Entities.Address>> ListAsync(Guid id)
        {
            var result = await _addressListByIdClient.ListAsync(id); 
            return result;
        }
    }
}
