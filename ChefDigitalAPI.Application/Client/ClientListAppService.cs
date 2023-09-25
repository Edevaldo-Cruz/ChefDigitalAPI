using ChefDigital.Domain.Interfaces;
using ChefDigitalAPI.Application.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientListAppService : IClientListAppService
    {
        private readonly IClientListService _clientListService;

        public ClientListAppService(IClientListService clientListService)
        {
            _clientListService = clientListService;
        }

        public Task<List<ChefDigital.Entities.Entities.Client>> List()
        { 
            var result = _clientListService.List();
            return result;
        }
    }
}
