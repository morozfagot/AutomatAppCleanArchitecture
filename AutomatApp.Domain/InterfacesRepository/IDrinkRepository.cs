using AutomatApp.Domain.Entities;
using System.Linq.Expressions;

namespace AutomatApp.Domain.InterfacesRepository
{
    public interface IDrinkRepository : IRepositoryBase<Drink>
    {
        Task<IEnumerable<Drink>> GetAllDrinksAsync(CancellationToken cancellationToken = default);
        Task<Drink> GetDrinkByIdAsync(int id,
        CancellationToken cancellationToken = default);
        Task<Drink> GetDrinkByConditionAsync(Expression<Func<Drink, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateDrink(Drink drink);
        void UpdateDrink(Drink drink);
        void DeleteDrink(Drink drink);
    }
}
