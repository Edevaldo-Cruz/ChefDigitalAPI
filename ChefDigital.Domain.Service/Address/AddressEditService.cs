using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressEditService : IAddressEditService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressEditService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Entities.Entities.Address> Edit(Guid id, Entities.Entities.Address address)
        {
            Entities.Entities.Address addressBanck = await _addressRepository.GetEntityById(id);
            bool existingAddress = await _addressRepository.ExistsAsync(a => a.Id == id);

            if (!existingAddress) throw new ArgumentValidationException($"O endereço com o ID {id} não foi encontrado.");

            address.Id = addressBanck.Id;
            address.SetDataAlteracao(DateTime.Now);
            Entities.Entities.Address newAddress = await _addressRepository.Edit(address);

            return newAddress;            
        }
    }
}
