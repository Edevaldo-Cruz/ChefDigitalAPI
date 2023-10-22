using ChefDigital.Entities.DTO.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressAppService
    {
        Task<ChefDigital.Entities.Entities.Address> DisableAsync(Guid id);
        Task<ChefDigital.Entities.Entities.Address> EditAsync(Guid id, AddressEditDTO address);
        Task<List<ChefDigital.Entities.Entities.Address>> ListAsync();
        Task<List<ChefDigital.Entities.Entities.Address>> ListAsync(Guid id);
    }
}
