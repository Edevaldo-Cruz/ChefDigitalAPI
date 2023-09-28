using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressDisableService : IAddressDisableService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressDisableService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Entities.Entities.Address> Disable(Guid id)
        {
            Entities.Entities.Address addressBank = new Entities.Entities.Address();
            addressBank = await _addressRepository.GetEntityById(id);

            if (addressBank == null)
                throw new ArgumentException("Endereço solicitado não existe");

            addressBank.Active = false;

            return addressBank;
        }
    }
}
