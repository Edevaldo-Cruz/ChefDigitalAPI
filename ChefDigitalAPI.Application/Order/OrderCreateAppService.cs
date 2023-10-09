using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Domain.Interfaces.Client;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Domain.Interfaces.OrderedItem;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigitalAPI.Application.Order.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order
{
    public class OrderCreateAppService : IOrderCreateAppService
    {
        private readonly IOrderCreateService _orderCreateService;
        private readonly IClientExistsService _clientExistsService;
        private readonly IClientCreateService _clientCreateService;
        private readonly IAddressCreateService _addressCreateService;
        private readonly IAddressExistsService _addressExistsService;
        private readonly IOrderedItemCreateService _orderedItemCreateService;
        private readonly IOrderUpdateValueService _orderUpdateValueService;

        public OrderCreateAppService(IOrderCreateService orderCreateService,
                                        IClientExistsService clientExistsService,
                                        IClientCreateService clientCreateService,
                                        IAddressCreateService addressCreateService,
                                        IAddressExistsService addressExistsService,
                                        IOrderedItemCreateService orderedItemCreateService,
                                        IOrderUpdateValueService orderUpdateValueService)
        {
            _orderCreateService = orderCreateService;
            _clientExistsService = clientExistsService;
            _clientCreateService = clientCreateService;
            _addressCreateService = addressCreateService;
            _addressExistsService = addressExistsService;
            _orderedItemCreateService = orderedItemCreateService;
            _orderUpdateValueService = orderUpdateValueService;
        }

        public async Task<bool> CreateAsync(OrderCreateDTO orderDTO)
        {
            decimal total = 0;
            Guid id;
            ChefDigital.Entities.Entities.Client client = await _clientExistsService.Exists(orderDTO.FirstName, orderDTO.Surname, orderDTO.Telephone);
            ChefDigital.Entities.Entities.Client newClient;


            if (client == null)
            {
                newClient = await _clientCreateService.CreateAsync(orderDTO.ToClient());

                if (newClient != null)
                {
                    await _addressCreateService.CreateAsync(newClient.Id, orderDTO.ToAddress());
                }

                id = newClient.Id;
            }
            else
            {
                id = client.Id;
            }

            bool addressExists = await _addressExistsService.IsAddressExists(id, orderDTO.Street, orderDTO.Number);

            if (!addressExists)
            {
                await _addressCreateService.CreateAsync(id, orderDTO.ToAddress());
            }

            var result = await _orderCreateService.CreateAsync(id);

            if (result != null) 
            {
                foreach (var item in orderDTO.OrderedItems)
                {
                    ChefDigital.Entities.Entities.OrderedItem newItem = new OrderedItem()
                    {
                        OrderId = result.Id,
                        Item = item.Item,
                        UnitValue = item.UnitValue,
                        ItemQuantity = item.ItemQuantity
                    };

                    await _orderedItemCreateService.CreateAsync(newItem);

                    total += (item.UnitValue *  item.ItemQuantity);
                };
            }

            await _orderUpdateValueService.UpdateAsync(result.Id, total);

            return true;

        }
    }
}
