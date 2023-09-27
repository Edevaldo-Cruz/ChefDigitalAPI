using ChefDigital.Entities.DTO;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientListService
    {
        Task<List<ClientDTO>> List();
    }
}
