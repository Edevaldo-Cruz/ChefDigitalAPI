using ChefDigital.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Client
{
    public class ClientCreateService : IClientCreateService
    {
        private readonly IClientRepository _clientRepository;

        public ClientCreateService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Entities.Entities.Client> Create(Entities.Entities.Client client)
        {
            bool existingClient = await _clientRepository.ExistsAsync(c => c.FisrtName == client.FisrtName && c.Telephone == client.Telephone);
            if (existingClient)
            {
                throw new ArgumentValidationException("O cliente já esta cadastrado.");
            }

            if (client != null)
            {

                /*
                * CRIAR ENDEREÇO DO CLIENTE  
                * RECUPERAR CLIENTID PARA SALVA NO ENDEREÇO
                * DESCOMENTAR CODIGO NO CONTEXTBASE
                */

                await _clientRepository.Add(client);
            }
            else
            {
                throw new ArgumentValidationException("Preencha as informações do cliente.");
            }

            

            return client;
        }
    }
}
