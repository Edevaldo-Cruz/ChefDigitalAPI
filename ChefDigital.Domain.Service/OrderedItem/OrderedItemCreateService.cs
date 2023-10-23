using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Interfaces.OrderedItem;
using ChefDigital.Entities.DTO;

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
            var result = await _repository.Add(orderedItem);

            if (result == null)
            {
                return false;
            }

            return true;
        }

    }
}
