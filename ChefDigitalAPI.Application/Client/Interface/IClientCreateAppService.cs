using ChefDigital.Entities.DTO;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientCreateAppService
    {
        Task<ClientDTO> Create(ClientDTO client);
    }
}
