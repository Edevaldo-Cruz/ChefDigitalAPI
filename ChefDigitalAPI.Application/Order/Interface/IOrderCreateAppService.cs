using ChefDigital.Entities.DTO;

namespace ChefDigitalAPI.Application.Order.Interface
{
    public interface IOrderCreateAppService
    {
        Task<bool> CreateAsync(OrderCreateDTO orderDTO);
    }
}
