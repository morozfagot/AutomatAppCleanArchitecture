using AutoMapper;
using AutomatApp.Application.Clients.Commands.UpdateWithdrawWallet;
using AutomatApp.Application.Wallets.Queries.GetBuyWalletByIdError;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.CheckWithdrawWallet
{
    public class CheckWithdrawWalletQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public Dictionary<int, int>? CheckCountCoins { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(Wallet wallet, GetBuyWalletByIdErrorQuery input), bool>()
                .ForMember(gbve =>
                gbve.ChangeCountDrinks,
                opt => opt.MapFrom(src => src.wallet.ShoppingCarts.
                Where(sc => sc.DrinkId == src.input.ChangeCountDrinks.Keys.ElementAt(sc.DrinkId))))
                .ForMember(gbve =>
                gbve.ChangeNameDrink,
                opt => opt.MapFrom(src => src.wallet.ShoppingCarts
                .Where(sc => sc.DrinkId == src.input.ChangeCountDrinks.Keys.ElementAt(sc.DrinkId))));

                CreateMap<ShoppingCart, string>()
                .ForMember(s =>
                s,
                opt => opt.MapFrom(src => src.Drink.Name));

                CreateMap<ShoppingCart, int>()
                .ForMember(i =>
                i,
                opt => opt.MapFrom(src => src.Count));
            }
        }

        public CheckWithdrawWalletQuery(UpdateWithdrawWalletQuery input)
        {
            Id = input.Id;
            CheckCountCoins = input.CheckCountCoins;
        }
    }
}
