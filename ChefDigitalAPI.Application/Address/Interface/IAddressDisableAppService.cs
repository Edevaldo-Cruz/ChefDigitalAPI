using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressDisableAppService
    {
        Task<ChefDigital.Entities.Entities.Address> Disable(Guid id);
    }
}
