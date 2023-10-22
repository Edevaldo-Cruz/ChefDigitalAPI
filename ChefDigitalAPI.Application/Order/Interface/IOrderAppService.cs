using ChefDigital.Entities.DTO;

namespace ChefDigitalAPI.Application.Order.Interface
{
    public interface IOrderAppService
    {
        Task<bool> CreateAsync(OrderCreateDTO orderDTO);
        Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id);
        Task<ChefDigital.Entities.Entities.Order> UpdateStatusOrderAsync(Guid id);
    }
}
