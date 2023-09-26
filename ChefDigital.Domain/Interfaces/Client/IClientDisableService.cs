using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientDisableService
    {
        Task<Entities.Entities.Client> Disable(Guid id);
    }
}
