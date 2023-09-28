using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressEditService
    {
        Task<Entities.Entities.Address> EditAsync (Guid id, Entities.Entities.Address address);
    }
}
