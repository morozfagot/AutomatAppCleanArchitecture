using AutomatApp.Domain.Entities;
using System.Linq.Expressions;

namespace AutomatApp.Domain.InterfacesRepository
{
    public interface IWalletRepository : IRepositoryBase<Wallet>
    {
        Task<IEnumerable<Wallet>> GetAllWalletsAsync(CancellationToken cancellationToken = default);
        Task<Wallet> GetWalletByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Wallet> GetWalletByConditionAsync(Expression<Func<Wallet, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateWallet(Wallet Wallet);
        void UpdateWallet(Wallet Wallet);
        void DeleteWallet(Wallet Wallet);
    }
}
