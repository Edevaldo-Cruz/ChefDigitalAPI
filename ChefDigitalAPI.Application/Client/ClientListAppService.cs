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
    public class ClientListAppService : IClientListAppService
    {
        private readonly IClientListService _clientListService;

        public ClientListAppService(IClientListService clientListService)
        {
            _clientListService = clientListService;
        }

        public Task<List<ClientListDTO>> ListAsync()
        { 
            var result = _clientListService.ListAsync();
            return result;
        }
    }
}
