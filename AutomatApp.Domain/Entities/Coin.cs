namespace AutomatApp.Domain.Entities
{
    public class Coin
    {
        public int Id { get; set; }
        public int Price { get; set; } //1,2,5,10
        public List<CoinCase>? CoinCases { get; set; }
    }
}
