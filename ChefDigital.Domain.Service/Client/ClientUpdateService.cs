using ChefDigital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientUpdateService : IClientUpdateService
    {
        private readonly IClientRepository _clientRepository;

        public ClientUpdateService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> Update(Guid id, Entities.Entities.Client client)
        {
            Entities.Entities.Client bankClient = new Entities.Entities.Client();
            bankClient = await _clientRepository.GetEntityById(id);

            bool existingClient = await _clientRepository.ExistsAsync(c => c.Id == client.Id);

            if (!existingClient)
            {
                throw new ArgumentValidationException("Preencha as informações do cliente.");
            }

            if (bankClient == null)
            {
                throw new ArgumentValidationException($"Cliente com o ID {id} não encontrado.");
            }

            client.Id = bankClient.Id;
            client.DataInclusao = bankClient.DataInclusao;
            client.DataAlteracao = DateTime.Now;
            client.Active = client.Active;
            await _clientRepository.Update(client);
            return client;
        }
    }
}
