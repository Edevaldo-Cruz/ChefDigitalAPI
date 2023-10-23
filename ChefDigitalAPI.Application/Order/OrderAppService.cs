using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.Address;
using ChefDigital.Domain.Interfaces.Client;
using ChefDigital.Domain.Interfaces.Message;
using ChefDigital.Domain.Interfaces.Order;
using ChefDigital.Domain.Interfaces.OrderedItem;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Entities.Enums;
using ChefDigitalAPI.Application.Order.Interface;

namespace ChefDigitalAPI.Application.Order
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderCreateService _orderCreateService;
        private readonly IClientRepository _clientRepository;
        private readonly IClientExistsService _clientExistsService;
        private readonly IClientCreateService _clientCreateService;
        private readonly IAddressCreateService _addressCreateService;
        private readonly IAddressExistsService _addressExistsService;
        private readonly IOrderedItemCreateService _orderedItemCreateService;
        private readonly IOrderUpdateValueService _orderUpdateValueService;
        private readonly IOrderBonusService _orderBonusService;
        private readonly IMessageService _messageService;

        private readonly IOrderUpdateStatusService _orderUpdateStatusService;
        private readonly IOrderCancelService _orderCancelService;

        public OrderAppService(IOrderCreateService orderCreateService,
                                        IClientExistsService clientExistsService,
                                        IClientCreateService clientCreateService,
                                        IAddressCreateService addressCreateService,
                                        IAddressExistsService addressExistsService,
                                        IOrderedItemCreateService orderedItemCreateService,
                                        IOrderUpdateValueService orderUpdateValueService,
                                        IOrderBonusService orderBonusService,
                                        IMessageService messageService,
                                        IOrderUpdateStatusService orderUpdateStatusService,
                                        IOrderCancelService orderCancelService,
                                        IClientRepository clientRepository)
        {
            _orderCreateService = orderCreateService;
            _clientExistsService = clientExistsService;
            _clientCreateService = clientCreateService;
            _addressCreateService = addressCreateService;
            _addressExistsService = addressExistsService;
            _orderedItemCreateService = orderedItemCreateService;
            _orderUpdateValueService = orderUpdateValueService;
            _orderBonusService = orderBonusService;
            _messageService = messageService;
            _orderUpdateStatusService = orderUpdateStatusService;
            _orderCancelService = orderCancelService;
            _clientRepository = clientRepository;
        }

        /*
                  Programa de Fidelidade

                  Para se qualificar para o programa de fidelidade, um cliente deve realizar 5 compras nos últimos 90 dias, 
                       cada uma com um valor igual ou superior a R$20.

                  Uma vez qualificado, o cliente terá direito a um desconto de 30% em sua próxima compra, desde que o valor
                       da compra seja igual ou superior a R$20. No entanto, o desconto está limitado a no máximo R$45.

                  Observe que o desconto é de 30% do valor da compra ou R$45, o que for menor.

                  Resumo das condições:
                  - 5 compras nos últimos 90 dias
                  - Cada compra com valor igual ou superior a R$20
                  - Desconto de 30%, limitado a R$45, na próxima compra de R$20 ou mais.
               */

        public async Task<bool> CreateAsync(OrderCreateDTO orderDTO)
        {
            Guid orderId = Guid.NewGuid();
            decimal subtotal = 0;
            var client = await _clientRepository.GetEntityById(orderDTO.ClientId);

            if (client == null)
                return false;

            var newOrder = await CreateNewOrder(orderDTO.ClientId, orderId, subtotal);

            if (orderDTO.OrderedItems != null)
            {
                subtotal = await AddOrderedItems(newOrder.Id, orderDTO.OrderedItems);
            }

            await _orderUpdateValueService.UpdateAsync(newOrder.Id, subtotal);

            string textEmail = ChefDigital.Entities.Enums.OrderStatusHelper.GetMessage(OrderStatusEnum.Processing);
            _messageService.SendMessage(client.Email, textEmail);

            return true;
        }


        public async Task<bool> CreateOrderNewClientAsync(OrderCreateNewClientDTO orderDTO)
        {
            Guid clientId;
            Guid orderId = Guid.NewGuid();
            decimal subtotal = 0;
            ChefDigital.Entities.Entities.Client client = await _clientExistsService.Exists(orderDTO.FirstName, orderDTO.Surname, orderDTO.Telephone);
            ChefDigital.Entities.Entities.Client newClient;

            if (client == null)
            {
                newClient = await _clientCreateService.CreateAsync(orderDTO.ToClient());
                if (newClient != null)
                {
                    await _addressCreateService.CreateAsync(newClient.Id, orderDTO.ToAddress());
                }

                clientId = newClient.Id;
            }
            else
            {
                clientId = client.Id;
            }

            bool addressExists = await _addressExistsService.IsAddressExists(clientId, orderDTO.Street, orderDTO.Number);

            if (!addressExists)
            {
                await _addressCreateService.CreateAsync(clientId, orderDTO.ToAddress());
            }

            var result = await CreateNewOrder(clientId, orderId, subtotal);
            if (orderDTO.OrderedItems != null)
            {
                subtotal = await AddOrderedItems(orderId, orderDTO.OrderedItems);
            }

            await _orderUpdateValueService.UpdateAsync(orderId, subtotal);

            if (result != null)
            {
                string textEmail = ChefDigital.Entities.Enums.OrderStatusHelper.GetMessage(OrderStatusEnum.Processing);
                _messageService.SendMessage(orderDTO.Email, textEmail);
            }

            return true;
        }

        private async Task<ChefDigital.Entities.Entities.Order> CreateNewOrder(Guid clientId, Guid orderId, decimal subtotal)
        {
            decimal discount = await _orderBonusService.Bonus(clientId, subtotal);

            ChefDigital.Entities.Entities.Order newOrder = new()
            {
                Id = orderId,
                ClientId = clientId,
                Subtotal = subtotal,
                Discount = discount
            };
            newOrder.SetTotal(subtotal, discount);

            var reusult = await _orderCreateService.CreateAsync(newOrder);
            return reusult;
        }

        public async Task<ChefDigital.Entities.Entities.Order> UpdateStatusOrderAsync(Guid id)
        {
            var result = await _orderUpdateStatusService.UpdateOrderStatusAsync(id);

            return result;
        }

        public async Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id)
        {
            var result = await _orderCancelService.CancelOrderAsync(id);
            return result;
        }

        private async Task<decimal> AddOrderedItems(Guid orderId, List<OrderedItemDTO> orderedItems)
        {
            decimal subtotal = 0;

            foreach (var item in orderedItems)
            {
                ChefDigital.Entities.Entities.OrderedItem newItem = new()
                {
                    OrderId = orderId,
                    Item = item.Item,
                    UnitValue = item.UnitValue,
                    ItemQuantity = item.ItemQuantity
                };

                bool save = await _orderedItemCreateService.CreateAsync(newItem);

                subtotal += (item.UnitValue * item.ItemQuantity);
            }

            return subtotal;
        }
    }
}
