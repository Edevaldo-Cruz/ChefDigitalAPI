using ChefDigital.Entities.DTO.Address;

namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressEditAppService
    {
        Task<ChefDigital.Entities.Entities.Address> EditAsync(Guid id, AddressEditDTO address);
    }
}
