using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public AddressRepository(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task<List<Address>> ListByIdClient(Guid id)
        {
            using (var bank = new ContextBase(_optionsBuilder))
            {
                var clients = await bank.Set<Address>()
                     .Where(a => a.ClientId == id)
                        .ToListAsync();
                
                return clients;
            }
        }

    }
}
