using AutomatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AutomatApp.Infrastructure.DbConfig
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(a => a.ClientId);
            builder.HasOne(a => a.Client)
                .WithOne(c => c.Administrator)
                .HasForeignKey<Administrator>(a => a.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
