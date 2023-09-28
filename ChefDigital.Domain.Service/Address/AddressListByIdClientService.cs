using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressListByIdClientService : IAddressListByIdClientService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressListByIdClientService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<Entities.Entities.Address>> List(Guid id)
        {
            List<Entities.Entities.Address> addresses = new List<Entities.Entities.Address>();
            addresses = await _addressRepository.ListByIdClient(id);

            if (addresses == null) 
                throw new ArgumentException("Cliente e endereço não encontrado.");

            return addresses;
        }
    }
}
