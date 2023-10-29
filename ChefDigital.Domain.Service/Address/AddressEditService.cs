using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.DTO.Address;
using ChefDigital.Entities.Entities.Generics;
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

        public async Task<Entities.Entities.Address> EditAsync(Guid id, Entities.Entities.Address address)
        {
            Entities.Entities.Address addressBanck = await _addressRepository.GetEntityById(id);
            bool existingClient = await _clientRepository.ExistsAsync(x => x.Id == address.ClientId);

            if (addressBanck == null)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    PropertyName = "Address",
                    Message = "O endereço não foi encontrado."
                };
                addressEmpty.Notitycoes.Add(notification);
                return addressEmpty;
            }

            if (!existingClient)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    PropertyName = "Address",
                    Message = "O cliente não foi encontrado."
                };
                addressEmpty.Notitycoes.Add(notification);
                return addressEmpty;
            }

            address.Id = addressBanck.Id;
            address.SetDateChange(DateTime.Now);
            Entities.Entities.Address newAddress = await _addressRepository.Edit(address);

            return newAddress;
        }
    }
}
