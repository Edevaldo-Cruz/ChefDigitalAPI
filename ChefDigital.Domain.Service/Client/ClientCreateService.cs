using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientCreateService : IClientCreateService
    {
        private readonly IClientRepository _clientRepository;

        public ClientCreateService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> CreateAsync(Entities.Entities.Client client)
        {
            bool existingClient = await _clientRepository.ExistsAsync(c => c.FirstName == client.FirstName && c.Telephone == client.Telephone);

            if (existingClient)
            {
                Notification notification = new()
                {
                    Message = "O cliente já está cadastrado.",
                    PropertyName = "Client"
                };

                client.Notitycoes.Add(notification);
                return client;
            }

            if (client == null)
            {
                Entities.Entities.Client clientEmpty = new();
                Notification notification = new()
                {
                    Message = "Preencha os dados do cliente.",
                    PropertyName = "Client"
                };

                clientEmpty.Notitycoes.Add(notification);
                return client;
            }

            Entities.Entities.Client newClient = await _clientRepository.Add(client);
            return newClient;
        }

    }
}
