using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatApp.Infrastructure.DbConfig
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.HasOne(sc => sc.Wallet).WithMany(w => w.ShoppingCarts).HasForeignKey(sc => sc.WalletId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(sc => sc.Drink).WithMany(d => d.ShoppingCarts).HasForeignKey(sc => sc.DrinkId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}