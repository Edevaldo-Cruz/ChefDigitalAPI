using ChefDigital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientListService : IClientListService
    {
        private readonly IClientRepository _clientRepository;

        public ClientListService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Entities.Entities.Client>> List()
        {
            return await _clientRepository.ClientListFilter(c => c.Active == true);
        }
    }
}
