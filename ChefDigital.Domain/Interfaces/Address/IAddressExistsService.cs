using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Address
{
    public interface IAddressExistsService
    {
        Task<bool> IsAddressExists(Guid id, string street, int number);
    }
}
    