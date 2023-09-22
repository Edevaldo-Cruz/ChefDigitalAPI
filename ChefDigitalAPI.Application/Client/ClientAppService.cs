using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientAppService : IClientAppService
    {
        private readonly IClientService _clientService;

        public ClientAppService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public Task<ChefDigital.Entities.Entities.Client> Add(ChefDigital.Entities.Entities.Client client)
        {
            var result = _clientService.Add(client);
            return result;
        }

        public Task<ChefDigital.Entities.Entities.Client> Disable(Guid id)
        {
            var result = _clientService.Disable(id);
            return result;
        }
    

        public Task<List<ChefDigital.Entities.Entities.Client>> ListClient()
        {
            var result = _clientService.ListClient();
            return result;
        }

        public Task<ChefDigital.Entities.Entities.Client> Update(Guid id, ChefDigital.Entities.Entities.Client client)
        {
            var result = _clientService.Update(id, client);
            return result;
        }
    }
}
