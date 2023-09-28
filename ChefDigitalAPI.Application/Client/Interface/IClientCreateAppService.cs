using ChefDigital.Entities.DTO.Client;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientCreateAppService
    {
        Task<ChefDigital.Entities.Entities.Client> Create(ClientCreateDTO client);
    }
}
