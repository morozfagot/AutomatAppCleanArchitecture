using AutomatApp.Domain.InterfacesRepository;
using AutomatApp.Infrastructure.Repositories;

namespace AutomatApp.Infrastructure.DbRepositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IClientRepository> _lazyClientRepository;
        private readonly Lazy<IAdministratorRepository> _lazyAdministratorRepository;
        private readonly Lazy<ICoinRepository> _lazyCoinRepository;
        private readonly Lazy<IWalletRepository> _lazyWalletRepository;
        private readonly Lazy<IDrinkRepository> _lazyDrinkRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(AutomatDbContext dbContext)
        {
            _lazyClientRepository = new Lazy<IClientRepository>(() => new ClientRepository(dbContext));
            _lazyAdministratorRepository = new Lazy<IAdministratorRepository>(() => new AdministratorRepository(dbContext));
            _lazyCoinRepository = new Lazy<ICoinRepository>(() => new CoinRepository(dbContext));
            _lazyWalletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(dbContext));
            _lazyDrinkRepository = new Lazy<IDrinkRepository>(() => new DrinkRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IClientRepository ClientRepository { get { return _lazyClientRepository.Value; } }
        public IAdministratorRepository AdministratorRepository { get { return _lazyAdministratorRepository.Value; } }
        public ICoinRepository CoinRepository { get { return _lazyCoinRepository.Value; } }
        public IWalletRepository WalletRepository { get { return _lazyWalletRepository.Value; } }
        public IDrinkRepository DrinkRepository { get { return _lazyDrinkRepository.Value; } }
        public IUnitOfWork UnitOfWork { get { return _lazyUnitOfWork.Value; } }
    }
}
