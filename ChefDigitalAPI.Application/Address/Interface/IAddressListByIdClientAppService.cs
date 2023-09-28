using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressListByIdClientAppService
    {
        Task<List<ChefDigital.Entities.Entities.Address>> List(Guid id);
    }
}
