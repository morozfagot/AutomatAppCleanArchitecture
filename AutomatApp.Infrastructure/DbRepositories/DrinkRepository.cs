using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AutomatApp.Domain.Entities;
using AutomatApp.Domain.InterfacesRepository;

namespace AutomatApp.Infrastructure.DbRepositories
{
    internal sealed class DrinkRepository : RepositoryBase<Drink>, IDrinkRepository
    {
        public DrinkRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Drink>> GetAllDrinksAsync(CancellationToken cancellationToken = default)
        {
            var result = await FindAll()
                .Include(d => d.ShoppingCarts)
                .ThenInclude(sc => sc.Wallet)
                .OrderBy(d => d.Id)
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Drink> GetDrinkByIdAsync(int id,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(d => d.Id.Equals(id))
                .Include(d => d.ShoppingCarts)
                .ThenInclude(sc => sc.Wallet)
                .SingleAsync(cancellationToken);

            return result;
        }

        public async Task<Drink> GetDrinkByConditionAsync(Expression<Func<Drink, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var result = await FindByCondition(d => d.Id.Equals(expression))
                .Include(d => d.ShoppingCarts)
                .ThenInclude(sc => sc.Wallet)
                .SingleAsync(cancellationToken);

            return result;
        }

        public void CreateDrink(Drink input)
        {
            Create(input);
        }

        public void UpdateDrink(Drink input)
        {
            Update(input);
        }

        public void DeleteDrink(Drink input)
        {
            Delete(input);
        }
    }
}