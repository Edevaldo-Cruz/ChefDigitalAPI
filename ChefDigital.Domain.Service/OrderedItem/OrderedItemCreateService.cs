using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.OrderedItem;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities.Generics;

namespace ChefDigital.Domain.Service.OrderedItem
{
    public class OrderedItemCreateService : IOrderedItemCreateService
    {
        private readonly IOrderedItemRepository _repository;

        public OrderedItemCreateService(IOrderedItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Entities.Entities.OrderedItem orderedItem)
        {
            if(ValidateOrderedItem(orderedItem, out string errorMessage))
            {
                var orderedItemWithNotification = CreateOrderedItemWithNotification(errorMessage);
                return false;
            }

            var result = await _repository.Add(orderedItem);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        private bool ValidateOrderedItem(Entities.Entities.OrderedItem orderedItem, out string errorMessage)
        {
            if (orderedItem == null)
            {
                errorMessage = "O item de pedido não pode ser nulo.";
                return true;
            }

            if (orderedItem.OrderId == Guid.Empty)
            {
                errorMessage = "O campo 'OrderId' deve ser preenchido.";
                return true;
            }

            if (string.IsNullOrWhiteSpace(orderedItem.Item))
            {
                errorMessage = "O campo 'Item' deve ser preenchido.";
                return true;
            }

            if (orderedItem.UnitValue <= 0)
            {
                errorMessage = "O campo 'UnitValue' deve ser maior que zero.";
                return true;
            }

            if (orderedItem.ItemQuantity <= 0)
            {
                errorMessage = "O campo 'ItemQuantity' deve ser maior que zero.";
                return true;
            }

            errorMessage = null;
            return false;
        }

        private Entities.Entities.OrderedItem CreateOrderedItemWithNotification(string errorMessage)
        {
            Entities.Entities.OrderedItem orderedItemWithNotification = new();
            Notification notification = new Notification
            {
                Message = errorMessage,
                PropertyName = "OrderedItem"
            };
            orderedItemWithNotification.Notitycoes.Add(notification);
            return orderedItemWithNotification;
        }
    }
}
