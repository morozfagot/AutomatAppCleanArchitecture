using AutoMapper;
using AutomatApp.Domain.InterfacesRepository;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.GetBuyWalletByIdError
{
    internal class GetBuyWalletByIdErrorQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        : IRequestHandler<GetBuyWalletByIdErrorQuery, GetBuyWalletByIdError>
    {
        public async Task<GetBuyWalletByIdError> Handle(GetBuyWalletByIdErrorQuery request,
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

            var result = mapper.Map<GetBuyWalletByIdError>((wallet, request));

            result.MinusWalletPrice = differenceWalletPrice;

            return result;
        }
    }
}
