using ChefDigital.Domain.Interfaces;
using ChefDigital.Entities.DTO;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChefDigital.Infra.Repository.Repositories
{
    public class ClientRepository : RepositoryGenerics<Client>, IClientRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public ClientRepository(DbContextOptions<ContextBase> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }

        public async Task<List<ClientDTO>> ClientListFilter(Expression<Func<Client, bool>> exClient)
        {
            using (var bank = new ContextBase(_optionsBuilder))
            {
                var clients = await bank.Set<Client>()
                    .Where(exClient)
                    .Select(c => new ClientDTO
                    {
                        Id = c.Id,
                        FisrtName = c.FisrtName,
                        Surname = c.Surname,
                        Telephone = c.Telephone
                    })
                    .ToListAsync();

                foreach (var client in clients)
                {
                    var addresses = await bank.Set<Address>()
                        .Where(a => a.ClientId == client.Id)
                        .ToListAsync();

                    client.Addresses = addresses;
                }

                return clients;
            }
        }



        public async Task<List<Client>> ClientList()
        {
            var teste = _optionsBuilder;
            using (var bank = new ContextBase(_optionsBuilder))
            {
                return await bank.Set<Client>().ToListAsync();
            }
        }

    }
}
