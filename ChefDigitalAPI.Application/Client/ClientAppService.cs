using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Domain.Interfaces.Client;
using ChefDigital.Entities.DTO.Client;
using ChefDigitalAPI.Application.Client.Interface;

namespace ChefDigitalAPI.Application.Client
{
    public class ClientAppService : IClientAppService
    {
        private readonly IClientCreateService _clientCreateService;
        private readonly IAddressCreateService _addressCreateService;
        private readonly IClientDisableService _clientDisableService;
        private readonly IClientListService _clientListService;
        private readonly IClientUpdateService _clientUpdateService;
        private readonly IClientSearchService _clientSearchService;

        public ClientAppService(IClientCreateService clientCreateService,
                                    IAddressCreateService addressCreateService,
                                    IClientDisableService clientDisableService,
                                    IClientListService clientListService,
                                    IClientUpdateService clientUpdateService,
                                    IClientSearchService clientSearchService)
        {
            _clientCreateService = clientCreateService;
            _addressCreateService = addressCreateService;
            _clientDisableService = clientDisableService;
            _clientListService = clientListService;
            _clientUpdateService = clientUpdateService;
            _clientSearchService = clientSearchService;
        }

        public async Task<ChefDigital.Entities.Entities.Client> Create(ClientCreateDTO client)
        {
            var newClient = await _clientCreateService.CreateAsync(client.ToClient());

            if (newClient != null && !newClient.HasNotifications)
                await _addressCreateService.CreateAsync(newClient.Id, client.ToAddress());

            return newClient;
        }

        public Task<ChefDigital.Entities.Entities.Client> DisableAsync(Guid id)
        {
            var result = _clientDisableService.DisableAsync(id);
            return result;
        }

        public Task<List<ClientListDTO>> ListAsync()
        {
            var result = _clientListService.ListAsync();
            return result;
        }

        public Task<ChefDigital.Entities.Entities.Client> EditAsync(Guid id, ClientEditDTO client)
        {
            var result = _clientUpdateService.EditAsync(id, client.ToClient());
            return result;
        }

        public Task<ChefDigital.Entities.Entities.Client> SearchCustomerAsync(Guid id)
        {
            var result = _clientSearchService.Search(id);
            return result;
        }
    }
}
