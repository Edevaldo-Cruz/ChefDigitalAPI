using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientDisableService : IClientDisableService
    {
        private readonly IClientRepository _clientRepository;

        public ClientDisableService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> DisableAsync(Guid id)
        {
            Entities.Entities.Client clientBank = new Entities.Entities.Client();
            clientBank = await _clientRepository.GetEntityById(id);

            if (clientBank == null)
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

            clientBank.SetActiveFalse();
            clientBank.SetDateChange(DateTime.Now);
            await _clientRepository.Edit(clientBank);

            return clientBank;
        }
    }
}
