using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Entities.DTO.Client;
using ChefDigitalAPI.Application.Client.Interface;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientCreateAppService : IClientCreateAppService
    {
        private readonly IClientCreateService _clientCreateService;
        private readonly IAddressCreateService _addressCreateService;

        public ClientCreateAppService(IClientCreateService clientCreateService,
                                        IAddressCreateService addressCreateService)
        {
            _clientCreateService = clientCreateService;
            _addressCreateService = addressCreateService;
        }

        public async Task<ChefDigital.Entities.Entities.Client> Create(ClientCreateDTO client)
        {
            var newClient = await _clientCreateService.CreateAsync(client.ToClient());

            if (newClient != null && !newClient.HasNotifications)
                await _addressCreateService.CreateAsync(newClient.Id, client.ToAddress());

            return newClient;
        }
    }
}
