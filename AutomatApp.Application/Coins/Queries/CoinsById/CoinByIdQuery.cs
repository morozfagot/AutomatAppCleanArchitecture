using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Coins.Queries.CoinsById
{
    internal class CoinByIdQuery
    {
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<CoinCase, CoinByIdSuccess>()
                .ForMember(cbis =>
                cbis.Id,
                opt => opt.MapFrom(src => src.CoinId))
                .ForMember(svm =>
                svm.Price,
                opt => opt.MapFrom(src => src.Coin.Price))
                .ForMember(d =>
                d.Count,
                o => o.MapFrom(s => s.Count));
            }
        }
    }
}
