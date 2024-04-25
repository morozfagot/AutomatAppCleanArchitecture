using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatApp.Infrastructure.DbConfig
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(w => w.Id);
            builder.HasOne(w => w.Client).WithOne(c => c.Wallet).HasForeignKey<Wallet>(w => w.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(w => w.ShoppingCarts).WithOne(sc => sc.Wallet).HasForeignKey(sc => sc.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(w => w.CoinCases).WithOne(cc => cc.Wallet).HasForeignKey(cc => cc.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}