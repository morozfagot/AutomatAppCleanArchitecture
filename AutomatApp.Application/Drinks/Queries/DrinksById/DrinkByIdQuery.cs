using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Drinks.Queries.DrinksById
{
    internal class DrinkByIdQuery
    {
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<ShoppingCart, DrinkByIdSuccess>()
                .ForMember(d =>
                d.Id,
                o => o.MapFrom(s => s.DrinkId))
                .ForMember(d =>
                d.Name,
                o => o.MapFrom(s => s.Drink.Name))
                .ForMember(d =>
                d.Price,
                o => o.MapFrom(s => s.Drink.Price))
                .ForMember(d =>
                d.Count,
                o => o.MapFrom(s =>s.Count));
            }
        }
    }
}
