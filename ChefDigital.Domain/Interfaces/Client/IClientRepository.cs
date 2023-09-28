using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.DTO.Client;
using ChefDigital.Entities.Entities;
using System.Linq.Expressions;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Entities.Entities.Client>
    {
        Task<List<ClientListDTO>> ClientListFilter(Expression<Func<Entities.Entities.Client, bool>> exClient);
    }
}
