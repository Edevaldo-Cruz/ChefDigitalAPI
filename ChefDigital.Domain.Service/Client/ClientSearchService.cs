using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientSearchService : IClientSearchService
    {
        private readonly IClientRepository _clientRepository;

        public ClientSearchService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Entities.Entities.Client> Search(Guid id)
        {
            var result = _clientRepository.GetEntityById(id);
            return result;
        }
    }
}
