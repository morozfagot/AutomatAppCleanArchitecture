using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutomatApp.Infrastructure.DbConfig
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Wallet).WithOne(w => w.Client)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Administrator).WithOne(a => a.Client)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(c => c.Login).IsUnique();
        }
    }
}