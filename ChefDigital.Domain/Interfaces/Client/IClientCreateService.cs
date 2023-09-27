using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientCreateService
    {
        Task<ClientDTO> Create(ClientDTO client);
    }
}
