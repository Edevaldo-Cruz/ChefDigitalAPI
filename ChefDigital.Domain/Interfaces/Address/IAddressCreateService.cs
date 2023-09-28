using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressCreateService
    {
        Task<Entities.Entities.Address> CreateAsync(Guid ClientId, Entities.Entities.Address address);
    }
}
