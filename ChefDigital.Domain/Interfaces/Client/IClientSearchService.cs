using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Client
{
    public interface IClientSearchService
    {
        Task<Entities.Entities.Client> Search(Guid id);
    }
}
