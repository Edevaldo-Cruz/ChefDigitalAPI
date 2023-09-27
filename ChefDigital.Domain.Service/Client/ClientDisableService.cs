using ChefDigital.Domain.Interfaces;
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

        public async Task<Entities.Entities.Client> Disable(Guid id)
        {
            Entities.Entities.Client clientBank = new Entities.Entities.Client();
            clientBank = await _clientRepository.GetEntityById(id);

            clientBank.SetActiveFalse();
            clientBank.SetDataAlteracao(DateTime.Now);
            await _clientRepository.Edit(clientBank);

            return clientBank;
        }
    }
}
