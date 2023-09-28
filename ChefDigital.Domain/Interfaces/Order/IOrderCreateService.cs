namespace ChefDigital.Domain.Interfaces.Order
{
    public interface IOrderCreateService
    {
        Task<Entities.Entities.Order> CreateAsync(Entities.DTO.OrderDTO orderDTO);
    }
}
