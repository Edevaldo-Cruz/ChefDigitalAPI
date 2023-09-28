using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientRepository : IGeneric<Client>
    {
        Task<List<ClientDTO>> ClientListFilter(Expression<Func<Client, bool>> exClient);       
    }
}
