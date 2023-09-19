using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ChefDigital.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ChefDigital.Infra.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        //erro no UseSqlServer instalar pacote entities.SQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            builder.Entity<Order>().ToTable("Orders").HasKey(t => t.Id);
            builder.Entity<Client>().ToTable("Client").HasKey(t => t.Id);
            builder.Entity<HistoryRequest>().ToTable("HistoryRequest").HasKey(t => t.Id);            
            builder.Entity<OrderedItem>().ToTable("OrderedItem").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=EDEVALDO\\SQLEXPRESS;Initial Catalog=ChefDigitalAPI; Integrated Security=True";
        }
    }
}
