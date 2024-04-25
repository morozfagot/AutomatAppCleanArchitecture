using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;

namespace AutomatApp.Infrastructure.DbRepositories
{
    internal sealed class WalletRepository : RepositoryBase<Wallet>, IWalletRepository
    {
        public WalletRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .Include(w => w.CoinCases)
                .ThenInclude(cc => cc.Coin)
                .OrderBy(d => d.Id)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Wallet> GetWalletByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(w => w.Id.Equals(id))
                .Include(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .Include(w => w.CoinCases)
                .ThenInclude(cc => cc.Coin)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Wallet> GetWalletByConditionAsync(Expression<Func<Wallet, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(w => w.Id.Equals(expression))
                .Include(w => w.ShoppingCarts)
                .ThenInclude(sc => sc.Drink)
                .Include(w => w.CoinCases)
                .ThenInclude(cc => cc.Coin)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateWallet(Wallet input)
        {
            Create(input);
        }

        public void UpdateWallet(Wallet input)
        {
            Update(input);
        }

        public void DeleteWallet(Wallet input)
        {
            Delete(input);
        }
    }
}