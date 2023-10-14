namespace ChefDigital.Domain.Interfaces.Order
{
    public interface IOrderCreateService
    {
        Task<Entities.Entities.Order> CreateAsync(Entities.Entities.Order order);
    }
}
