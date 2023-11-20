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

        public async Task<ChefDigital.Entities.Entities.Order> CreateAsync(OrderCreateDTO orderDTO)
        {
            Guid orderId = Guid.NewGuid();
            decimal subtotal = 0;
            
            //trocar essa interação
            var client = await _clientRepository.GetEntityById(orderDTO.ClientId);

            if (client == null)
                return null;

            if (orderDTO.OrderedItems != null)
            {
                foreach (var item in orderDTO.OrderedItems)
                {
                    ChefDigital.Entities.Entities.OrderedItem newItem = new()
                    {
                        UnitValue = item.UnitValue,
                        ItemQuantity = item.ItemQuantity
                    };
                    subtotal += (item.UnitValue * item.ItemQuantity);
                }
            }
            var newOrder = await CreateNewOrder(orderDTO, orderId, subtotal);

            //await _orderUpdateValueService.UpdateAsync(newOrder.Id, subtotal);

            string textEmail = ChefDigital.Entities.Enums.OrderStatusHelper.GetMessage(OrderStatusEnum.Processing);
            _messageService.SendMessage(client.Email, textEmail);

            return newOrder;
        }

        public async Task<ChefDigital.Entities.Entities.Order> CreateOrderNewClientAsync(OrderCreateNewClientDTO orderDTO)
        {
            Guid clientId;
            Guid orderId = Guid.NewGuid();
            ChefDigital.Entities.Entities.Client client = await _clientExistsService.Exists(orderDTO.FirstName, orderDTO.Surname, orderDTO.Telephone);
            ChefDigital.Entities.Entities.Client newClient;
            decimal subtotal = 0;

            if (client == null)
            {
                newClient = await _clientCreateService.CreateAsync(orderDTO.ToClient());
                if (newClient != null)
                    await _addressCreateService.CreateAsync(newClient.Id, orderDTO.ToAddress());

                clientId = newClient.Id;
            }
            else
            {
                clientId = client.Id;
                bool addressExists = await _addressExistsService.IsAddressExists(clientId, orderDTO.Street, orderDTO.Number);
                if (!addressExists)
                    await _addressCreateService.CreateAsync(clientId, orderDTO.ToAddress());
            }

            if (orderDTO.OrderedItems != null)
            {
                foreach (var item in orderDTO.OrderedItems)
                {
                    ChefDigital.Entities.Entities.OrderedItem newItem = new()
                    {
                        UnitValue = item.UnitValue,
                        ItemQuantity = item.ItemQuantity
                    };
                    subtotal += (item.UnitValue * item.ItemQuantity);
                }
            }

            var result = await CreateNewOrderForNewCustomer(orderDTO, clientId, subtotal);
            if (result != null)
            {
                string textEmail = ChefDigital.Entities.Enums.OrderStatusHelper.GetMessage(OrderStatusEnum.Processing);
                _messageService.SendMessage(orderDTO.Email, textEmail);
            }

            return result;
        }

        private async Task<ChefDigital.Entities.Entities.Order> CreateNewOrder(OrderCreateDTO orderDTO, Guid orderId, decimal subtotal)
        {

            decimal discount = await _orderBonusService.Bonus(orderDTO.ClientId, subtotal);

            ChefDigital.Entities.Entities.Order newOrder = new()
            {
                Id = orderId,
                ClientId = orderDTO.ClientId,
                Discount = discount,
                Items = orderDTO.OrderedItems.Select(item => new OrderedItem
                {
                    OrderId = orderId,
                    Item = item.Item,
                    UnitValue = item.UnitValue,
                    ItemQuantity = item.ItemQuantity
                }).ToList()
            };
            newOrder.SetSubtotal();
            newOrder.SetTotal();

            var result = await _orderCreateService.CreateAsync(newOrder);
            return result;
        }

        private async Task<ChefDigital.Entities.Entities.Order> CreateNewOrderForNewCustomer(OrderCreateNewClientDTO orderDTO, Guid clientId, decimal subtotal)
        {
            decimal discount = await _orderBonusService.Bonus(clientId, subtotal);

            ChefDigital.Entities.Entities.Order newOrder = new()
            {
                ClientId = clientId,
                Discount = discount,
                Items = orderDTO.OrderedItems.Select(item => new OrderedItem
                {
                    Item = item.Item,
                    UnitValue = item.UnitValue,
                    ItemQuantity = item.ItemQuantity
                }).ToList()
            };
            newOrder.SetSubtotal();
            newOrder.SetTotal();

            var result = await _orderCreateService.CreateAsync(newOrder);
            return result;
        }

        public async Task<ChefDigital.Entities.Entities.Order> UpdateStatusOrderAsync(Guid id)
        {
            var result = await _orderUpdateStatusService.UpdateOrderStatusAsync(id);

            if (result == null)
                return null;

            OrderStatusEnum status = result.Status;
            string textEmail = ChefDigital.Entities.Enums.OrderStatusHelper.GetMessage(status);

            var client = await _clientRepository.GetEntityById(result.ClientId);

            _messageService.SendMessage(client.Email, textEmail);

            return result;
        }

        public async Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id)
        {
            var result = await _orderCancelService.CancelOrderAsync(id);
            return result;
        }
    }
}
