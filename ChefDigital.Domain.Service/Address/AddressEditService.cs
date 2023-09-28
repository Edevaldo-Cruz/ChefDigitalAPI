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
        private readonly IClientRepository _clientRepository;

        public AddressEditService(IAddressRepository addressRepository, IClientRepository clientRepository)
        {
            _addressRepository = addressRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Address> Edit(Guid id, Entities.Entities.Address address)
        {
            Entities.Entities.Address addressBanck = await _addressRepository.GetEntityById(id);

            bool existingAddress = await _addressRepository.ExistsAsync(a => a.Id == id);
            if (!existingAddress) throw new ArgumentValidationException("O endereço não foi encontrado.");

            // O Cliente deve existir para salvar no banco de dados
            bool existingClient = await _clientRepository.ExistsAsync(c => c.Id == address.ClientId);
            if (!existingClient) throw new ArgumentValidationException("O cliente não foi encontrado.");

            address.Id = addressBanck.Id;
            address.SetDataAlteracao(DateTime.Now);
            Entities.Entities.Address newAddress = await _addressRepository.Edit(address);

            return newAddress;            
        }
    }
}
