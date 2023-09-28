using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressListByIdClientService
    {
        Task<List<Entities.Entities.Address>> ListAsync(Guid id);
    }
}
