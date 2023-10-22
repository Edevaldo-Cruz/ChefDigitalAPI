using ChefDigital.Entities.DTO.Client;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientAppService
    {
        Task<ChefDigital.Entities.Entities.Client> Create(ClientCreateDTO client);
        Task<ChefDigital.Entities.Entities.Client> DisableAsync(Guid id);
        Task<List<ClientListDTO>> ListAsync();
        Task<ChefDigital.Entities.Entities.Client> EditAsync(Guid id, ClientEditDTO client);
    }
}
