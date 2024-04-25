namespace AutomatApp.Domain.InterfacesRepository
{
    public interface IRepositoryManager
    {
        IClientRepository ClientRepository { get; }
        IAdministratorRepository AdministratorRepository { get; }
        ICoinRepository CoinRepository { get; }
        IWalletRepository WalletRepository { get; }
        IDrinkRepository DrinkRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}