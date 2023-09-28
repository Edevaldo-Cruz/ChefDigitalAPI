using ChefDigital.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigitalAPI.Application.Order.Interface
{
    public interface IOrderCreateAppService
    {
        Task<bool> CreateAsync(OrderDTO orderDTO);
    }
}
