using ChefDigital.Entities.DTO;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientListAppService
    {
        Task<List<ClientDTO>> List();
    }
}
