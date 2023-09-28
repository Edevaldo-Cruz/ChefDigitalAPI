using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Address
{
    public class AddressListByIdClientService : IAddressListByIdClientService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressListByIdClientService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<Entities.Entities.Address>> ListAsync(Guid id)
        {
            List<Entities.Entities.Address> addresses = new();
            addresses = await _addressRepository.ListByIdClient(id);

            if (addresses == null)
            {
                Entities.Entities.Address addressEmpty = new();
                Notification notification = new()
                {
                    Message = "Cliente e endereço não encontrado.",
                    PropertyName = "Address"
                };
                addressEmpty.Notitycoes.Add(notification);
            }
            return addresses;
        }
    }
}
