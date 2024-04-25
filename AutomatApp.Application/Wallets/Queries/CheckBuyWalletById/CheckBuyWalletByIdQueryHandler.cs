using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.CheckBuyWalletById
{
    internal class CheckBuyWalletByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CheckBuyWalletByIdQuery, bool>
    {
        public async Task<bool> Handle(CheckBuyWalletByIdQuery request,
            CancellationToken cancellationToken = default)
        {
            var wallet = await repositoryManager.WalletRepository.GetWalletByIdAsync(request.Id, cancellationToken);

            int totalWalletCoinPrice = 0;
            int totalWalletDrinkPrice = 0;

            foreach (var coinCase in wallet.CoinCases)
            {
                var price = coinCase.Coin.Price;
                var count = coinCase.Count;
                var totalCoinPrice = price * count;
                totalWalletCoinPrice += totalCoinPrice;
            }

            foreach (var shoppingCart in wallet.ShoppingCarts)
            {
                var price = shoppingCart.Drink.Price;
                var count = shoppingCart.Count;
                var totalDrinkPrice = price * count;
                totalWalletDrinkPrice += totalDrinkPrice;
            }

            if (totalWalletCoinPrice - totalWalletDrinkPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
