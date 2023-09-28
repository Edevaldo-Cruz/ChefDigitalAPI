using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Order
{
    public interface IOrderUpdateValueService
    {
        Task UpdateAsync(Guid orderId, decimal value);
    }
}
