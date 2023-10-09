//using ChefDigital.Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ChefDigital.Domain.Service.Client
//{
//    public class ClientUpdateService : IClientUpdateService
//    {
//        private readonly IClientRepository _clientRepository;

//        public ClientUpdateService(IClientRepository clientRepository)
//        {
//            _clientRepository = clientRepository;
//        }

//        public async Task<Entities.Entities.Client> Edit(Guid id, Entities.Entities.Client client)
//        {
//            Entities.Entities.Client bankClient = new Entities.Entities.Client();
//            bankClient = await _clientRepository.GetEntityById(id);

//            //bool existingClient = await _clientRepository.ExistsAsync(c => c.Id == client.Id);
//            //if (!existingClient)
//            //{
//            //    throw new ArgumentValidationException($"Cliente com o ID {id} não encontrado.");
//            //}   

//            if (bankClient == null)
//            {
//                throw new ArgumentValidationException($"Cliente com o ID {id} não encontrado.");
//            }

//            client.SetDataAlteracao(DateTime.Now);
//            client.SetActiveFalse();
//            await _clientRepository.Edit(client);
//            return client;
//        }
//    }
//}


using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientUpdateService : IClientUpdateService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ContextBase _dbContext; // Injete o DbContext se necessário

        public ClientUpdateService(IClientRepository clientRepository, ContextBase dbContext)
        {
            _clientRepository = clientRepository;
            _dbContext = dbContext;
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

            // Chame o novo método para salvar as alterações no banco de dados diretamente
            await SaveClientChangesDirectly(client);

            return client;
        }

        private async Task SaveClientChangesDirectly(Entities.Entities.Client client)
        {
            // Qualquer lógica adicional antes de salvar as alterações diretamente no banco de dados
            // Certifique-se de que as alterações sejam salvas de forma assíncrona

            // Use o DbContext para salvar as alterações diretamente no banco de dados
            // O exemplo a seguir é para fins de teste; em uma aplicação real, evite essa prática e use o repositório.
            _dbContext.Entry(client).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}

