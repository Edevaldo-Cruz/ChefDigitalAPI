using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.OrderedItem
{
    public interface IOrderedItemCreateService
    {
        Task<Entities.DTO.OrderedItem.CreateResultDTO> CreateAsync(Entities.Entities.OrderedItem orderedItem);
    }
}
