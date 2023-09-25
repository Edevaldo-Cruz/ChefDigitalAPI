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
            builder.Entity<OrderedItem>().ToTable("OrderedItem").HasKey(t => t.Id);

            builder.Entity<Address>().ToTable("Address")
                .HasKey(t => t.Id);  

            //builder.Entity<Client>()
            //    .HasMany(c => c.Addresses)  
            //    .WithOne(a => a.Client)  
            //    .HasForeignKey(a => a.ClientId);  

            base.OnModelCreating(builder);
        }


        public string ObterStringConexao()
        {
            return "Data Source=EDEVALDO\\SQLEXPRESS;Initial Catalog=ChefDigitalAPI; Integrated Security=True";
        }
    }
}
