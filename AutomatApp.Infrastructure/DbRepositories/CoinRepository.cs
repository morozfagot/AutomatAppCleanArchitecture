using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutomatApp.Infrastructure.DbRepositories
{
    public class CoinRepository : RepositoryBase<Coin>, ICoinRepository
    {
        public CoinRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Coin>> GetAllCoinsAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(c => c.CoinCases)
                .ThenInclude(cc => cc.Wallet)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Coin> GetCoinByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(d => d.Id.Equals(id))
                .Include(c => c.CoinCases)
                .ThenInclude(cc => cc.Wallet)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Coin> GetCoinByConditionAsync(Expression<Func<Coin, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(d => d.Id.Equals(expression))
                .Include(c => c.CoinCases)
                .ThenInclude(cc => cc.Wallet)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateCoin(Coin input)
        {
            Create(input);
        }

        public void UpdateCoin(Coin input)
        {
            Update(input);
        }

        public void DeleteCoin(Coin input)
        {
            Delete(input);
        }
    }
}
