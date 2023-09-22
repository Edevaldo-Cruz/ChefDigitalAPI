using ChefDigital.Entities.Entities;

namespace ChefDigitalAPI.Application.Client
{
    public interface IClientAppService
    {
        Task<ChefDigital.Entities.Entities.Client> Add(ChefDigital.Entities.Entities.Client client);
        Task<ChefDigital.Entities.Entities.Client> Update(Guid id, ChefDigital.Entities.Entities.Client client);
        Task<List<ChefDigital.Entities.Entities.Client>> ListClient();
        Task<ChefDigital.Entities.Entities.Client> Disable(Guid id);
    }
}
