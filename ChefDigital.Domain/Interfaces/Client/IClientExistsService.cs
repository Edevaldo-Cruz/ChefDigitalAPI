using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Client
{
    public interface IClientExistsService
    {
        Task<Entities.Entities.Client> Exists(string firstname, string surname, string telephone);
    }
}
