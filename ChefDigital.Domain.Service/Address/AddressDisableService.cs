using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Entities.Entities;
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
            }

            addressBank.Active = false;

            return addressBank;
        }
    }
}
