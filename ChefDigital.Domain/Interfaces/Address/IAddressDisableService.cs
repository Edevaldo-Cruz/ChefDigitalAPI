using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressDisableService
    {
        Task<Entities.Entities.Address> DisableAsync(Guid id);
    }
}
