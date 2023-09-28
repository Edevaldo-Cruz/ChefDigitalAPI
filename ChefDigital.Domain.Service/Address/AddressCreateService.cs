using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressCreateService : IAddressCreateService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressCreateService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Entities.Entities.Address> CreateAsync(Guid ClientId, Entities.Entities.Address newClient)
        {
            Entities.Entities.Address newAddress = new Entities.Entities.Address();
            newAddress.ClientId = ClientId;
            newAddress.Street = newClient.Street;
            newAddress.City = newClient.City;
            newAddress.Number = newClient.Number;
            newAddress.Neighborhood = newClient.Neighborhood;
            newAddress.ZipCode = newClient.ZipCode;

            await _addressRepository.Add(newAddress);
            return newAddress;
        }
    }
}
