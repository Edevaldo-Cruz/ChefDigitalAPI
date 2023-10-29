using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities.Generics;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientUpdateService : IClientUpdateService
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdateService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> EditAsync(Guid id, Entities.Entities.Client client)
        {
            Entities.Entities.Client bankClient = await _clientRepository.GetEntityById(id);

            if (bankClient == null)
            {
                Entities.Entities.Client clientEmpty = new();
                Notification notification = new()
                {
                    PropertyName = "Client",
                    Message = $"Cliente com o ID {id} não encontrado."
                };

                clientEmpty.Notitycoes.Add(notification);
                return clientEmpty;
            }

            client.Id = bankClient.Id;
            client.SetDataAlteracao(DateTime.Now);

            var result = await _clientRepository.Edit(client);
            return result;
        }

    }
}

