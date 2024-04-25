namespace AutomatApp.Domain.Entities
{
    public class CoinCase
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int CoinId { get; set; }
        public Coin? Coin { get; set; }
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
