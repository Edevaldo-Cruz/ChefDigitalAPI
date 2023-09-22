using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> Add(Entities.Entities.Client client)
        {
            bool existingClient = await _clientRepository.ExistsAsync(c => c.Name == client.Name && c.Telephone == client.Telephone);
            if (existingClient)
            {
                throw new ArgumentValidationException("O cliente já esta cadastrado.");
            }

            if (client != null)
            {
                client.Id = Guid.NewGuid();
                client.DataInclusao = DateTime.Now;
                client.DataAlteracao = DateTime.MinValue;
                client.Active = true;
                await _clientRepository.Add(client);
            }
            else
            {
                throw new ArgumentValidationException("Preencha as informações do cliente.");
            }

            return client;
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

        public async Task<List<Entities.Entities.Client>> ListClient()
        {
            return await _clientRepository.ClientListFilter(c => c.Id != null);
        }

        public async Task<Entities.Entities.Client> Disable(Guid id)
        {
            Entities.Entities.Client clientBank = new Entities.Entities.Client();
            clientBank = await _clientRepository.GetEntityById(id);

            clientBank.Active = false;

            return clientBank;
        }
    }
}
