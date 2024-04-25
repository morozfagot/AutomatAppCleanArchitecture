using AutoMapper;
using AutomatApp.Application.Clients.Queries.GetBuyDrinkError;
using AutomatApp.Application.ShoppingCarts.Commands.UpdateBuyDrink;
using AutomatApp.Domain.Entities;
using MediatR;

namespace AutomatApp.Application.Wallets.Queries.CheckBuyWalletById
{
    public class CheckBuyWalletByIdQuery : IRequest<bool>
    {
        public int Id { get; set; }
        public Dictionary<int, int>? ChangeCountDrinks { get; set; }

        public CheckBuyWalletByIdQuery(UpdateBuyWalletCommand input)
        {
            Id = input.Id;
            ChangeCountDrinks = input.ChangeCountDrinks;
        }
    }
}
