using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using System.Net;

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

            if (ValidateClient(client, out string errorMessage))
            {
                return CreateClientWithNotification(errorMessage);
            }

            bool existingClient = await _clientRepository.ExistsAsync(c => c.FirstName == client.FirstName && c.Telephone == client.Telephone);

            if (existingClient)
            {
                Entities.Entities.Client clientExists = new Entities.Entities.Client();
                Notification notification = new Notification
                {
                    Message = "O cliente já está cadastrado.",
                    PropertyName = "Client"
                };

                clientExists.Notitycoes.Add(notification);
                return clientExists;
            }

            Entities.Entities.Client newClient = await _clientRepository.Add(client);
            return newClient;
        }

        private bool ValidateClient(Entities.Entities.Client client, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(client.FirstName))
            {
                errorMessage = "O campo 'FirstName' deve ser preenchido";
                return true;
            }

            if (string.IsNullOrWhiteSpace(client.Surname))
            {
                errorMessage = "O campo 'Surname' deve ser preenchido";
                return true;
            }

            if (string.IsNullOrWhiteSpace(client.Telephone))
            {
                errorMessage = "O campo 'Telephone' deve ser preenchido";
                return true;
            }

            if (string.IsNullOrWhiteSpace(client.Email))
            {
                errorMessage = "O campo 'Email' deve ser preenchido";
                return true;
            }

            errorMessage = null;
            return false;
        }

        private Entities.Entities.Client CreateClientWithNotification(string message)
        {
            Entities.Entities.Client clientWithNotification = new Entities.Entities.Client();
            Notification notification = new Notification
            {
                Message = message,
                PropertyName = "Client"
            };
            clientWithNotification.Notitycoes.Add(notification);
            return clientWithNotification;
        }


    }
}
