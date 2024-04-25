using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;

namespace AutomatApp.Infrastructure.DbRepositories
{
    internal sealed class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientWithWalletByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(id))
                .Include(c => c.Wallet)
                .ThenInclude(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .Include(c => c.Wallet)
                .ThenInclude(w => w.CoinCases)
                .ThenInclude(cc => cc.Coin)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(expression))
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Client> GetClientWithWalletByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(c => c.Id.Equals(expression))
                .Include(c => c.Wallet)
                .ThenInclude(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .Include(c => c.Wallet)
                .ThenInclude(w => w.CoinCases)
                .ThenInclude(cc => cc.Coin)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateClient(Client input)
        {
            Create(input);
        }

        public void UpdateClient(Client input)
        {
            Update(input);
        }

        public void DeleteClient(Client input)
        {
            Delete(input);
        }
    }
}