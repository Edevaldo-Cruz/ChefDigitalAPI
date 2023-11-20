using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderUpdateStatusService : IOrderUpdateStatusService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderUpdateStatusService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ChefDigital.Entities.Entities.Order> UpdateOrderStatusAsync(Guid id)
        {
            Notification notification = new();
            Entities.Entities.Order orderBank = await _orderRepository.GetEntityById(id);
            if (orderBank == null)
            {
                Entities.Entities.Order orderEmpty = new();
                notification.Message = "Pedido não encontrado.";
                notification.PropertyName = "Order";

                orderEmpty.Notitycoes.Add(notification);
                return orderEmpty;
            }

            if (orderBank.Status == Entities.Enums.OrderStatusEnum.Canceled)
            {
                notification.Message = "O pedido está cancelado.";
                notification.PropertyName = "Order";

                orderBank.Notitycoes.Add(notification);
                return orderBank;
            }

            if (orderBank.Status == Entities.Enums.OrderStatusEnum.Sent)
            {
                notification.Message = "O pedido finalizado, pois já foi entregue.";
                notification.PropertyName = "Order";

                orderBank.Notitycoes.Add(notification);
                return orderBank;
            }

            orderBank.SetStatus();
            await _orderRepository.Edit(orderBank);

            return orderBank;
        }
    }
}
