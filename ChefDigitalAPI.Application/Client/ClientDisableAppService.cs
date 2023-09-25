using ChefDigital.Domain.Interfaces;
using ChefDigitalAPI.Application.Client.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientDisableAppService : IClientDisableAppService
    {
        private readonly IClientDisableService _clientDisableService;

        public ClientDisableAppService(IClientDisableService clientDisableService)
        {
            _clientDisableService = clientDisableService;
        }

        public Task<ChefDigital.Entities.Entities.Client> Disable(Guid id)
        {
           var result = _clientDisableService.Disable(id);
            return result;
        }
    }
}
