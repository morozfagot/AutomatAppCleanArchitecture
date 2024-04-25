using AutoMapper;
using AutomatApp.Application.Wallets.Queries.GetBuyWalletError;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.Wallets.Commands.UpdateBuyWalletById
{
    public class UpdateBuyWalletByIdCommand : IRequest<UpdateBuyWalletByIdSuccess>
    {
        public int Id { get; set; }
        public Dictionary<int, int>? ChangeCountDrinks { get; set; }
        public Dictionary<int, int>? ChangeCountCoins { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(Wallet wallet, UpdateBuyWalletByIdCommand input), UpdateBuyWalletByIdSuccess>()
                .ForMember(g =>
                g.ChangeCountDrinks,
                o => o.MapFrom(s => s.wallet.ShoppingCarts.
                Where(c => c.DrinkId == s.input.ChangeCountDrinks.Keys.ElementAt(c.DrinkId))))
                .ForMember(g =>
                g.ChangeNameDrink,
                o => o.MapFrom(s => s.wallet.ShoppingCarts
                .Where(c => c.DrinkId == s.input.ChangeCountDrinks.Keys.ElementAt(c.DrinkId))));

                CreateMap<ShoppingCart, string>()
                .ForMember(s =>
                s,
                o => o.MapFrom(s => s.Drink.Name));

                CreateMap<ShoppingCart, int>()
                .ForMember(i =>
                i,
                o => o.MapFrom(s => s.Count));
            }
        }
    }
}
