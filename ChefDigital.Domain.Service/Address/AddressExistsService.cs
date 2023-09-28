using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressExistsService : IAddressExistsService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressExistsService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Task<bool> IsAddressExists(Guid id, string street, int number)
        {
           return _addressRepository.ExistsAsync(a => a.ClientId == id && a.Street == street && a.Number == number);
        }
    }
}
