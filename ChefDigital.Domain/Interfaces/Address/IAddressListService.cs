namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressListService
    {
        Task<List<Entities.Entities.Address>> List();
    }
}
