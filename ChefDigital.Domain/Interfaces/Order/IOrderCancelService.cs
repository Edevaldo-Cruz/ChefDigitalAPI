﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Order
{
    public interface IOrderCancelService
    {
        Task<ChefDigital.Entities.Entities.Order> CancelOrderAsync(Guid id);
    }
}
