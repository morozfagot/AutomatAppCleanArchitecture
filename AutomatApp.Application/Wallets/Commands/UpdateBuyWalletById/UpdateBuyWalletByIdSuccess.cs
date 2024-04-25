using AutomatApp.Application.AdministrationDrinks.Queries.DrinkById;
using AutomatApp.Application.Coins.Queries.CoinsById;

namespace AutomatApp.Application.Wallets.Commands.UpdateBuyWalletById
{
    public class UpdateBuyWalletByIdSuccess
    {
        public int Id { get; set; }

        public List<DrinkByIdSuccess>? Drinks { get; set; }
        public int ChangeCount { get; set; }
        public int Cash { get; set; }
    }
}
