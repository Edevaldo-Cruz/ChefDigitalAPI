using ChefDigital.Entities.DTO.Client;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientListAppService
    {
        Task<List<ClientListDTO>> ListAsync();
    }
}
