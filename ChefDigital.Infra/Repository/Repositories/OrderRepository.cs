using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public OrderRepository(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task<bool> CheckClientOrders(Guid clientId)
        {
            var ninetyDaysAgo = DateTime.Now.AddDays(-90);

            using (var bank = new ContextBase(_optionsBuilder))
            {
                var qualifyingOrders = await bank.Set<Order>()
                    .OrderByDescending(o => o.InclusionDate)
                    .Take(5)
                    .Where(o => o.ClientId == clientId && o.InclusionDate >= ninetyDaysAgo && o.TotalOrderValue >= 20 && o.Discount == 0)
                    .ToListAsync();

                return qualifyingOrders.Count >= 5;
            }
        }

    }
}
