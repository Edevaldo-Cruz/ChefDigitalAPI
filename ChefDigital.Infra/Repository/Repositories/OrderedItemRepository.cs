using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class OrderedItemRepository : Repository<OrderedItem>, IOrderedItemRepository
    {
        public Task<List<Address>> ListByIdClient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
