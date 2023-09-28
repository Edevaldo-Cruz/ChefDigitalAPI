using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientExistsService : IClientExistsService
    {
        private readonly IClientRepository _clientRepository;

        public ClientExistsService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Entities.Entities.Client> Exists(string firstname, string surname, string telephone)
        {
           return _clientRepository.ExistsEntityAsync(c => c.FirstName == firstname && c.Surname == surname && c.Telephone == telephone);
        }
    }
}
