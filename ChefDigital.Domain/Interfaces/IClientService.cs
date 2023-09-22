using ChefDigital.Entities.Entities;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientService
    {
        Task<Entities.Entities.Client> Add(Client client);
        Task<Entities.Entities.Client> Update(Guid id, Client client);
        Task<List<Client>> ListClient();
        Task<Client> Disable(Guid id);
    }
}
