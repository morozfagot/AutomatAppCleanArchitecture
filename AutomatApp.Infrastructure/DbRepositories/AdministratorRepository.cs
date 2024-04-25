using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutomatApp.Infrastructure.DbRepositories
{
    public class AdministratorRepository : RepositoryBase<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Administrator>> GetAllAdministratorsAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(a => a.Client)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Administrator> GetAdministratorByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(a => a.ClientId.Equals(id))
                .Include(a => a.Client)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Administrator> GetAdministratorWithShoppingCartByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.ClientId.Equals(id))
                .Include(a => a.Client)
                .ThenInclude(c => c.Wallet)
                .ThenInclude(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Administrator> GetAdministratorByConditionAsync(Expression<Func<Administrator, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.ClientId.Equals(expression))
                .Include(a => a.Client)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Administrator> GetAdministratorWithShoppingCartByConditionAsync(Expression<Func<Administrator, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.ClientId.Equals(expression))
                .Include(a => a.Client)
                .ThenInclude(c => c.Wallet)
                .ThenInclude(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateAdministrator(Administrator input)
        {
            Create(input);
        }

        public void UpdateAdministrator(Administrator input)
        {
            Update(input);
        }

        public void DeleteAdministrator(Administrator input)
        {
            Delete(input);
        }
    }
}
