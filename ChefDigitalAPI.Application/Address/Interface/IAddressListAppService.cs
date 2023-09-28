using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Address.Interface
{
    public interface IAddressListAppService
    {
        Task<List<ChefDigital.Entities.Entities.Address>> List();
    }
}
