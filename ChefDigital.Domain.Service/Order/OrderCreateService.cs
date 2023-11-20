using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Entities.Generics;
using ChefDigital.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderCreateService : IOrderCreateService
    {
       
        private readonly IOrderRepository _orderRepository;

        public OrderCreateService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Entities.Entities.Order> CreateAsync(Entities.Entities.Order order)
        {
            if (ValidateOrder(order, out string errorMessage))
                return CreateOrderWithNotification(errorMessage);

            var newOrder = await _orderRepository.Add(order);

            return newOrder;
        }

        private bool ValidateOrder(Entities.Entities.Order order, out string errorMessage)
        {
            if (order.ClientId == Guid.Empty)
            {
                errorMessage = "O campo 'ClientId' é obrigatório";
                return true;
            }

            if (order.Items == null || !order.Items.Any())
            {
                errorMessage = "O campo 'Items' é obrigatório";
                return true;
            }

            if (order.Items.Any(i => i.UnitValue <=0))
            {
                errorMessage = "O campo 'UnitValue' não deve ser menor igual a zero.";
                return true;
            }

            if (order.Items.Any(i => i.ItemQuantity <= 0))
            {
                errorMessage = "O campo 'ItemQuantity' não deve ser menor igual a zero.";
                return true;
            }

            if (order.Discount < 0)
            {
                errorMessage = "O campo 'Discount' não pode ser negativo";
                return true;
            }


            if (!Enum.IsDefined(typeof(OrderStatusEnum), order.Status))
            {
                errorMessage = "Status inválido";
                return true;
            }

            errorMessage = null;
            return false;
        }

        private Entities.Entities.Order CreateOrderWithNotification(string errorMessage)
        {
            Entities.Entities.Order orderWithNotification = new();
            Notification notification = new Notification
            {
                Message = errorMessage,
                PropertyName = "Order",
            };

            orderWithNotification.Notitycoes.Add(notification);
            return orderWithNotification;
        }


    }
}
