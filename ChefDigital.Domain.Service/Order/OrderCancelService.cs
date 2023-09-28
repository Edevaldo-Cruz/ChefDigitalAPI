using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Entities.Entities.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderCancelService : IOrderCancelService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCancelService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id)
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
                notification.Message = "O pedido já se encontra cancelado.";
                notification.PropertyName = "Order";

                orderBank.Notitycoes.Add(notification);
            }

            if (orderBank.Status == Entities.Enums.OrderStatusEnum.Sent)
            {
                notification.Message = "O pedido não pode ser cancelado pois já foi entregue.";
                notification.PropertyName = "Order";

                orderBank.Notitycoes.Add(notification);
            }

            orderBank.SetStatusCanceled();
            await _orderRepository.Edit(orderBank);

            return orderBank;
        }
    }
}
