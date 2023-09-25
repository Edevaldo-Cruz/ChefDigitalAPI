using ChefDigital.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces
{
    public interface IClientUpdateService
    {
        Task<Client> Update(Guid id, Client client);
    }
}
