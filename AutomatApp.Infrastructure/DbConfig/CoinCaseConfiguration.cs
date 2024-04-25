using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AutomatApp.Infrastructure.DbConfig
{
    public class CoinCaseConfiguration : IEntityTypeConfiguration<CoinCase>
    {
        public void Configure(EntityTypeBuilder<CoinCase> builder)
        {
            builder.HasKey(cc => cc.Id);
            builder.HasOne(cc => cc.Wallet).WithMany(w => w.CoinCases).HasForeignKey(cc => cc.WalletId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(cc => cc.Coin).WithMany(c => c.CoinCases).HasForeignKey(sc => sc.CoinId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
