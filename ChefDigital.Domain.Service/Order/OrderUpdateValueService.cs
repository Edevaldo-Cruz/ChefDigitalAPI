using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderUpdateValueService : IOrderUpdateValueService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderUpdateValueService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task UpdateAsync(Guid orderId, decimal value)
        {
           var orderBank = await _orderRepository.GetEntityById(orderId);

            if (orderBank != null)
            {
                orderBank.SetTotal();

                await _orderRepository.Edit(orderBank);
            }
        }

       
    }
}
