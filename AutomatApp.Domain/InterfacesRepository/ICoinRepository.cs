using AutomatApp.Domain.Entities;
using System.Linq.Expressions;

namespace AutomatApp.Domain.InterfacesRepository
{
    public interface ICoinRepository : IRepositoryBase<Coin>
    {
        Task<IEnumerable<Coin>> GetAllCoinsAsync(CancellationToken cancellationToken = default);
        Task<Coin> GetCoinByIdAsync(int id,
        CancellationToken cancellationToken = default);
        Task<Coin> GetCoinByConditionAsync(Expression<Func<Coin, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateCoin(Coin Coin);
        void UpdateCoin(Coin Coin);
        void DeleteCoin(Coin Coin);
    }
}
