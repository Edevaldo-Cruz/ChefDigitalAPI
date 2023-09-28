using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Service.Order
{
    public class OrderCreateService : IOrderCreateService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderedItemRepository _orderedItem;


        public OrderCreateService(IClientRepository clientRepository,
                                    IAddressRepository addressRepository,
                                    IOrderRepository orderRepository,
                                    IOrderedItemRepository orderedItem)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _orderedItem = orderedItem;
        }

        public async Task<Entities.Entities.Order> CreateAsync(OrderDTO orderDTO)
        {
            var newOrder = await _orderRepository.Add(orderDTO.ToOrder());

            if (newOrder == null)
            {
                return null;
            }

            return newOrder;
        }
    }
}
