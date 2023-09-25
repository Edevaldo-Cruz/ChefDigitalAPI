using ChefDigital.Domain.Interfaces;
using ChefDigitalAPI.Application.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientCreateAppService : IClientCreateAppService
    {
        private readonly IClientCreateService _clientCreateService;

        public ClientCreateAppService(IClientCreateService clientCreateService)
        {
            _clientCreateService = clientCreateService;
        }

        public Task<ChefDigital.Entities.Entities.Client> Create(ChefDigital.Entities.Entities.Client client)
        {
            var result = _clientCreateService.Create(client);
            return result;
        }
    }
}
