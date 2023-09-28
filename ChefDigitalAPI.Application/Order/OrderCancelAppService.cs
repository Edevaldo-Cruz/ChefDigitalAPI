using ChefDigital.Domain.Interfaces.Order;
using ChefDigitalAPI.Application.Order.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order
{
    public class OrderCancelAppService : IOrderCancelAppService
    {
        private readonly IOrderCancelService _orderCancelService;

        public OrderCancelAppService(IOrderCancelService orderCancelService)
        {
            _orderCancelService = orderCancelService;
        }

        public async Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id)
        {
            var result = await _orderCancelService.CancelOrderAsync(id);
            return result;
        }
    }
}
