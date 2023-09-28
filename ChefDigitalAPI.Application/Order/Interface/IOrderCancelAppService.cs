using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order.Interface
{
    public interface IOrderCancelAppService
    {
        Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id);
    }
}
