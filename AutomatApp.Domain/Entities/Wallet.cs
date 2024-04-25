namespace AutomatApp.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public List<ShoppingCart>? ShoppingCarts { get; set; }
        public List<CoinCase>? CoinCases { get; set; }
        public int TotalPrice { get; set; }
    }
}
