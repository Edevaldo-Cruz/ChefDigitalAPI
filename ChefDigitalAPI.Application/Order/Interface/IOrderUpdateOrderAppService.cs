using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order.Interface
{
    public interface IOrderUpdateOrderAppService
    {
        Task<ChefDigital.Entities.Entities.Order> UpdateOrderAsync(Guid id);
    }
}
