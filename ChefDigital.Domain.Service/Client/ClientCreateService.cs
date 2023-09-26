using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientCreateService : IClientCreateService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public ClientCreateService(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public async Task<ChefDigital.Entities.Entities.Client> Create(ChefDigital.Entities.Entities.Client client)
        {
            bool existingClient = await _clientRepository.ExistsAsync(c => c.FisrtName == client.FisrtName && c.Telephone == client.Telephone);
            if (existingClient)
            {
                throw new ArgumentValidationException("O cliente já está cadastrado.");
            }

            if (client != null)
            {
                Guid id = client.Id;
                await _clientRepository.Add(client);

                if (client.Addresses != null)
                {
                    foreach (var address in client.Addresses)
                    {
                        var newAddress = new Address(id, address.Street, address.Number, address.Neighborhood, address.City, address.State, address.ZipCode, address.Country);

                        await _addressRepository.Add(newAddress);
                    }
                }
            }
            else
            {
                throw new ArgumentValidationException("Preencha as informações do cliente.");
            }

            return client;
        }



    }
}
