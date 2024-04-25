using AutomatApp.Domain.Entities;
using AutomatApp.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace AutomatApp.Infrastructure
{
    public sealed class AutomatDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<CoinCase> CoinCases { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public AutomatDbContext(DbContextOptions<AutomatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new AdministratorConfiguration());

            modelBuilder.ApplyConfiguration(new WalletConfiguration());

            modelBuilder.ApplyConfiguration(new CoinConfigurtion());
            modelBuilder.ApplyConfiguration(new CoinCaseConfiguration());

            modelBuilder.ApplyConfiguration(new DrinkConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}