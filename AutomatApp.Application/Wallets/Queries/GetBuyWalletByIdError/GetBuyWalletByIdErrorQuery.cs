using AutoMapper;
using AutomatApp.Application.Wallets.Commands.UpdateBuyWalletById;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.GetBuyWalletByIdError
{
    public class GetBuyWalletByIdErrorQuery : IRequest<GetBuyWalletByIdError>
    {
        public int Id { get; set; }
        public Dictionary<int, int>? ChangeCountDrinks { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<(Wallet wallet, GetBuyWalletByIdErrorQuery input), GetBuyWalletByIdError>()
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

        public GetBuyWalletByIdErrorQuery(UpdateBuyWalletByIdCommand input)
        {
            Id = input.Id;
            ChangeCountDrinks = input.ChangeCountDrinks;
        }
    }
}
