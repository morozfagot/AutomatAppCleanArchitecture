using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatApp.Infrastructure.DbConfig
{
    internal class CoinConfigurtion : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.CoinCases).WithOne(cc => cc.Coin).HasForeignKey(c => c.CoinId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
