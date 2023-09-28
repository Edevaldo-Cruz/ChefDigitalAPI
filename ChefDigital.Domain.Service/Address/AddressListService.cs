using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressListService : IAddressListService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressListService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<Entities.Entities.Address>> List()
        {
            List<ChefDigital.Entities.Entities.Address> listAddress = await _addressRepository.List();
            return listAddress;
        }
    }
}
