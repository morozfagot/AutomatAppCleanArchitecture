using AutomatApp.Domain.InterfacesRepository;

namespace AutomatApp.Infrastructure.DbRepositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AutomatDbContext _dbContext;
        public UnitOfWork(AutomatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                int result = await _dbContext.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
