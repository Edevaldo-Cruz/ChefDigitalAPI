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

        public OrderBonusService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<decimal> Bonus(Guid clientId, decimal value)
        {
            if(value < 20)
               return 0;

            bool discount = await _orderRepository.CheckClientOrders(clientId);

            if (discount)
            {
                if(value < 150)
                    return value * 0.3m;

                if (value > 150)
                    return 150 * 0.3m;
            }
            return 0;
        }
    }
}
