using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.OrderedItem;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities.Generics;
using static System.Net.Mime.MediaTypeNames;

namespace ChefDigital.Domain.Service.OrderedItem
{
    public class OrderedItemCreateService : IOrderedItemCreateService
    {
        private readonly IOrderedItemRepository _repository;

        public OrderedItemCreateService(IOrderedItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Entities.DTO.OrderedItem.CreateResultDTO> CreateAsync(Entities.Entities.OrderedItem orderedItem)
        {
            var result = new Entities.DTO.OrderedItem.CreateResultDTO();

            if (ValidateOrderedItem(orderedItem, out string errorMessage))
            {
                result.IsSuccess = false;
                result.OrderedItem = CreateOrderedItemWithNotification(errorMessage);
            }
            else
            {
                result.IsSuccess = true;
                result.OrderedItem = await _repository.Add(orderedItem);
            }

            return result;
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
