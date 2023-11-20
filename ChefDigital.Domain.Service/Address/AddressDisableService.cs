using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressDisableService : IAddressDisableService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressDisableService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Entities.Entities.Address> DisableAsync(Guid id)
        {
            Entities.Entities.Address addressBank = new();
            addressBank = await _addressRepository.GetEntityById(id);

            if (addressBank == null)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    Message = "Cliente e endereço não encontrado.",
                    PropertyName = "Address"
                };
                addressEmpty.Notitycoes.Add(notification);
                return addressEmpty;
            }

            if (addressBank.Active == false)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    Message = "O endereço já se encontra inativo.",
                    PropertyName = "Address"
                };
                addressEmpty.Notitycoes.Add(notification);
                return addressEmpty;
            }

            addressBank.Active = false;
            Entities.Entities.Address newAddress = await _addressRepository.Edit(addressBank);

            return addressBank;
        }
    }
}
