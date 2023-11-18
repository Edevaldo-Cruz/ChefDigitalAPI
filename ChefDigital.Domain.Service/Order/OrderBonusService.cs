using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderBonusService : IOrderBonusService
    {
        private readonly IOrderRepository _orderRepository;
        decimal minValue = 20;
        decimal maxValue = 150;
        decimal discountValue = 0.3m;

        public OrderBonusService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<decimal> Bonus(Guid clientId, decimal value)
        {
            if(value < minValue)
               return 0;

            bool discount = await _orderRepository.CheckClientOrders(clientId);

            if (discount)
            {
                if(value < maxValue)
                    return value * discountValue;

                if (value >= maxValue)
                    return maxValue * discountValue;
            }
            return 0;
        }
    }
}
