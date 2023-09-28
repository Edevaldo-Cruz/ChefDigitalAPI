using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO.Client;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public ClientRepository(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task<List<ClientListDTO>> ClientListFilter(Expression<Func<Client, bool>> exClient)
        {
            using (var bank = new ContextBase(_optionsBuilder))
            {
                var clients = await bank.Set<Client>()
                    .Where(exClient)
                    .Select(c => new ClientListDTO
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        Surname = c.Surname,
                        Telephone = c.Telephone,
                        Addresses = c.Addresses
                    })
                    .ToListAsync();

                return clients;
            }
        }
    }
}
