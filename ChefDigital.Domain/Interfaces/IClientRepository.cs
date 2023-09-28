using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientRepository : IGeneric<Client>
    {
        Task<List<ClientDTO>> ClientListFilter(Expression<Func<Client, bool>> exClient);
    }
}
