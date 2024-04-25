using AutoMapper;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Coins.Queries.CoinsById
{
    public class CoinByIdSuccess
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        
    }
}
