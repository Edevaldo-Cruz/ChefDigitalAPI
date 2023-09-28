using ChefDigital.Entities.DTO.Client;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientListService
    {
        Task<List<ClientListDTO>> ListAsync();
    }
}
