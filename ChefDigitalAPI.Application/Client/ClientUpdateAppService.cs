using ChefDigital.Domain.Interfaces;
using ChefDigitalAPI.Application.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client
{

    public class ClientUpdateAppService : IClientUpdateAppService
    {
        private readonly IClientUpdateService _clientUpdateService;

        public ClientUpdateAppService(IClientUpdateService clientUpdateService)
        {
            _clientUpdateService = clientUpdateService;
        }

        public Task<ChefDigital.Entities.Entities.Client> Edit(Guid id, ChefDigital.Entities.Entities.Client client)
        {
            var result = _clientUpdateService.Edit(id, client);
            return result;
        }
    }
}
