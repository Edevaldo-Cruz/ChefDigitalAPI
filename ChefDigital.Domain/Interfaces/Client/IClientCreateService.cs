using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientCreateService
    {
        Task<Entities.Entities.Client> CreateAsync(Entities.Entities.Client client);
    }
}
