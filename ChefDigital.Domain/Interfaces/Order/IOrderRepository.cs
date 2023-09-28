using ChefDigital.Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Entities.Entities.Order>
    {
    }
}
