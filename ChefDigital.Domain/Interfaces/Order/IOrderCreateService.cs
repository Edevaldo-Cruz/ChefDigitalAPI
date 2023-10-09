namespace ChefDigital.Domain.Interfaces.Order
{
    public interface IOrderCreateService
    {
        Task<Entities.Entities.Order> CreateAsync(Guid clientId);
    }
}
