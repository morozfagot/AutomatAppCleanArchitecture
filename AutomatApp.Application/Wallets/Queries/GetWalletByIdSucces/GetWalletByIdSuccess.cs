using AutoMapper;
using AutomatApp.Application.Coins.Queries.CoinsById;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Application.Wallets.Queries.GetWalletByIdSucces
{
    public class GetWalletByIdSuccess
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<DrinkByIdSuccess>? Drinks { get; set; }
        public List<CoinByIdSuccess>? Stocks { get; set; }
        public int TotalPrice { get; set; }


    }
}
