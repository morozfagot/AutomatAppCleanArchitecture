using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Drinks.Queries.DrinksById
{
    public class DrinkByIdSuccess
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
