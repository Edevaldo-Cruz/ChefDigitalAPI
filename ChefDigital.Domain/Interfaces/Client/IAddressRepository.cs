using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<Entities.Entities.Address> 
    {
        Task<List<Entities.Entities.Address>> ListByIdClient(Guid id);
    }
}
