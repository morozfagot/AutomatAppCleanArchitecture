using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatApp.Infrastructure.DbConfig
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasMany(d => d.ShoppingCarts).WithOne(sc => sc.Drink).HasForeignKey(sc => sc.DrinkId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}