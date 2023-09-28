using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class AddressRepository : RepositoryGenerics<Address>, IAddressRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public AddressRepository(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }


        //public async Task<List<Address>> AddressList()
        //{
        //    using (var bank = new ContextBase(_optionsBuilder))
        //    {
        //        return await bank.Set<Address>().ToListAsync();
        //    }
        //}
    }
}
