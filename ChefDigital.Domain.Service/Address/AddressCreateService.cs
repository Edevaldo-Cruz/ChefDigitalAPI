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

        public AddressCreateService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Entities.Entities.Address> CreateAsync(Guid ClientId, Entities.Entities.Address newClient)
        {
            if (string.IsNullOrWhiteSpace(newClient.Street) ||
                    string.IsNullOrWhiteSpace(newClient.City) ||
                    newClient.Number <= 0 ||
                    string.IsNullOrWhiteSpace(newClient.Neighborhood) ||
                    string.IsNullOrWhiteSpace(newClient.ZipCode))
            {
                Entities.Entities.Address incompleteAddress = new();
                Notification notification = new()
                {
                    PropertyName = "Address",
                    Message = "Preencha todos os campos do endereço."
                };

                incompleteAddress.Notitycoes.Add(notification);
                return incompleteAddress;
            }

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
