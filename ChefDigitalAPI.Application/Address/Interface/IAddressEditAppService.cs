namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressEditAppService
    {
        Task<ChefDigital.Entities.Entities.Address> Edit(Guid id, ChefDigital.Entities.Entities.Address address);
    }
}
