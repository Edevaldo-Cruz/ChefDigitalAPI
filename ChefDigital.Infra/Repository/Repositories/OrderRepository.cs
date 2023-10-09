﻿using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
    }
}