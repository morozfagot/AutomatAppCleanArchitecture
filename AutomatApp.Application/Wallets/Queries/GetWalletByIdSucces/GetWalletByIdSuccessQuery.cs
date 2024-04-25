using AutoMapper;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.GetWalletByIdSucces
{
    public class GetWalletByIdSuccessQuery : IRequest<GetWalletByIdSuccess>
    {
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Wallet, GetWalletByIdSuccess>()
                .ForMember(wbis =>
                wbis.Drinks,
                opt => opt.MapFrom(src => src.ShoppingCarts))
                .ForMember(wbis =>
                wbis.Coins,
                opt => opt.MapFrom(src => src.CoinCases));
            }
        }
    }
}
