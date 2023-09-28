using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO.Client;
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

        public Task<ChefDigital.Entities.Entities.Client> EditAsync(Guid id, ClientEditDTO client)
        {
            var result = _clientUpdateService.EditAsync(id, client.ToClient());
            return result;
        }
    }
}
