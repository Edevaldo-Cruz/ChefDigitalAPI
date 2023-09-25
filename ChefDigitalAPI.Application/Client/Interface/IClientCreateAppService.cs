using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientCreateAppService
    {
        Task<ChefDigital.Entities.Entities.Client> Create(ChefDigital.Entities.Entities.Client client);
    }
}
