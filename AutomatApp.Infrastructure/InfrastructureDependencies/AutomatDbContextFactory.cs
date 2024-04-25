using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutomatApp.Infrastructure.InfrastructureDependencies
{
    public class AutomatDbContextFactory : IDesignTimeDbContextFactory<AutomatDbContext>
    {
        public AutomatDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutomatDbContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=ftjhgfhhdf;Host=localhost;Port=5432;Database=DbTrade;");

            return new AutomatDbContext(optionsBuilder.Options);
        }
    }
}
