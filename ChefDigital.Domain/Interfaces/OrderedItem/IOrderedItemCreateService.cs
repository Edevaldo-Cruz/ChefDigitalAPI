using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.OrderedItem
{
    public interface IOrderedItemCreateService
    {
        Task<bool> CreateAsync(Entities.Entities.OrderedItem orderedItem);
    }
}
