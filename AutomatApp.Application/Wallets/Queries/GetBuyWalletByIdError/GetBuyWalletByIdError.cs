namespace AutomatApp.Application.Wallets.Queries.GetBuyWalletByIdError
{
    public class GetBuyWalletByIdError
    {
        public int Id { get; set; }
        public List<string>? ChangeNameDrink { get; set; }
        public List<int>? ChangeCountDrinks { get; set; }
        public int MinusWalletPrice { get; set; }
    }
}
