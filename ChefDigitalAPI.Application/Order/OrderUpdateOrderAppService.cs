using ChefDigital.Domain.Interfaces.Order;
using ChefDigitalAPI.Application.Order.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order
{
    public class OrderUpdateOrderAppService : IOrderUpdateOrderAppService
    {
        private readonly IOrderUpdateStatusService _orderUpdateStatusService;

        public OrderUpdateOrderAppService(IOrderUpdateStatusService orderUpdateOrderService)
        {
            _orderUpdateStatusService = orderUpdateOrderService;
        }

        public async Task<ChefDigital.Entities.Entities.Order> UpdateStatusOrderAsync(Guid id)
        {
            var result = await _orderUpdateStatusService.UpdateOrderStatusAsync(id);

            return result;
        }
    }
}
