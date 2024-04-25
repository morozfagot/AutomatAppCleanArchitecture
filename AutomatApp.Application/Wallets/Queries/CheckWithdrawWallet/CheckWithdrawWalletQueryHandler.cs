using AutoMapper;
using MediatR;
using AutomatApp.Application.Clients.Queries.GetBuyDrinkError;
using AutomatApp.Domain.InterfacesRepository;

namespace AutomatApp.Application.Wallets.Queries.CheckWithdrawWallet
{
    internal class CheckWithdrawWalletQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<CheckWithdrawWalletQuery, bool>
    {
        public async Task<bool> Handle(CheckWithdrawWalletQuery request,
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

            var differenceWalletPrice = totalWalletCoinPrice - totalWalletDrinkPrice;

            var result = mapper.Map<GetBuyWalletError>((wallet, request));

            if (differenceWalletPrice > 0)
            {
                result.MinusWalletPrice = ;
            }
        }
    }
}
