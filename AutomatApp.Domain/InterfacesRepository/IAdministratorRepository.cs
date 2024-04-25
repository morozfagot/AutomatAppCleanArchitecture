using AutomatApp.Domain.Entities;
using System.Linq.Expressions;

namespace AutomatApp.Domain.InterfacesRepository
{
    public interface IAdministratorRepository : IRepositoryBase<Administrator>
    {
        Task<IEnumerable<Administrator>> GetAllAdministratorsAsync(CancellationToken cancellationToken = default);
        Task<Administrator> GetAdministratorByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Administrator> GetAdministratorWithShoppingCartByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Administrator> GetAdministratorByConditionAsync(Expression<Func<Administrator, bool>> expression,
            CancellationToken cancellationToken = default);
        Task<Administrator> GetAdministratorWithShoppingCartByConditionAsync(Expression<Func<Administrator, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateAdministrator(Administrator client);
        void UpdateAdministrator(Administrator client);
        void DeleteAdministrator(Administrator client);
    }
}
