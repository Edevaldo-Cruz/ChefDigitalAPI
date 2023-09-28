using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientDisableAppService
    {
        Task<ChefDigital.Entities.Entities.Client> DisableAsync(Guid id);
    }
}
