using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientListAppService
    {
        Task<List<ChefDigital.Entities.Entities.Client>> List();
    }
}
