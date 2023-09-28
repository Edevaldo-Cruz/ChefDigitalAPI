using ChefDigital.Entities.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Client.Interface
{
    public interface IClientUpdateAppService
    {
        Task<ChefDigital.Entities.Entities.Client> EditAsync(Guid id, ClientEditDTO client);
    }
}
