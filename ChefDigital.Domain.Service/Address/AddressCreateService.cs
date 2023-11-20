using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
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
        private readonly IClientRepository _clientRepository;

        public AddressCreateService(IAddressRepository addressRepository, IClientRepository clientRepository)
        {
            _addressRepository = addressRepository;
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Address> CreateAsync(Guid clientId, Entities.Entities.Address address)
        {
            if (await _clientRepository.GetEntityById(clientId) == null)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    PropertyName = "Addres",
                    Message = $"Cliente não encontrado."
                };
                addressEmpty.Notitycoes.Add(notification);
                return addressEmpty;
            }

            if (ValidateAddress(address, out string errorMessage))
            {
                return CreateAddressWithNotification(errorMessage);
            }

            Entities.Entities.Address newAddress = new Entities.Entities.Address();
            newAddress.ClientId = clientId;
            newAddress.Street = address.Street;
            newAddress.City = address.City;
            newAddress.Number = address.Number;
            newAddress.Neighborhood = address.Neighborhood;
            newAddress.ZipCode = address.ZipCode;
            newAddress.Active = true;

            await _addressRepository.Add(newAddress);
            return newAddress;
        }

        private bool ValidateAddress(Entities.Entities.Address address, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(address.Street))
            {
                errorMessage = "O campo 'Street' é obrigatório";
                return true;
            }

            if (address.Number <= 0)
            {
                errorMessage = "O campo 'Number' deve ser um número positivo";
                return true;
            }

            if (string.IsNullOrWhiteSpace(address.Neighborhood))
            {
                errorMessage = "O campo 'Neighborhood' é obrigatório";
                return true;
            }

            if (string.IsNullOrWhiteSpace(address.City))
            {
                errorMessage = "O campo 'City' é obrigatório";
                return true;
            }

            if (string.IsNullOrWhiteSpace(address.ZipCode))
            {
                errorMessage = "O campo 'ZipCode' é obrigatório";
                return true;
            }

            errorMessage = null;
            return false;
        }

        private Entities.Entities.Address CreateAddressWithNotification(string errorMessage)
        {
            Entities.Entities.Address addressWithNotification = new();
            Notification notification = new Notification
            {
                Message = errorMessage,
                PropertyName = "Address",
            };

            addressWithNotification.Notitycoes.Add(notification);
            return addressWithNotification;
        }

    }
}
