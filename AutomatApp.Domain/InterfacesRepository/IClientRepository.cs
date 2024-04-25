using AutomatApp.Domain.Entities;
using System.Linq.Expressions;

namespace AutomatApp.Domain.InterfacesRepository
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync(CancellationToken cancellationToken = default);
        Task<Client> GetClientByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientWithWalletByIdAsync(int id,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default);
        Task<Client> GetClientWithWalletByConditionAsync(Expression<Func<Client, bool>> expression,
            CancellationToken cancellationToken = default);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}