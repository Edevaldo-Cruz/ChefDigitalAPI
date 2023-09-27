using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO;
using ChefDigitalAPI.Application.Client.Interface;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientCreateAppService : IClientCreateAppService
    {
        private readonly IClientCreateService _clientCreateService;

        public ClientCreateAppService(IClientCreateService clientCreateService)
        {
            _clientCreateService = clientCreateService;
        }

        public Task<ClientDTO> Create(ClientDTO client)
        {
            var result = _clientCreateService.Create(client);
            return result;
        }
    }
}
