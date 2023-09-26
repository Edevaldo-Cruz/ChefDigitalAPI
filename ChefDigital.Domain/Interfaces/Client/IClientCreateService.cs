using ChefDigital.Entities.Entities;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientCreateService
    {
        Task<Client> Create(Client client);
    }
}
