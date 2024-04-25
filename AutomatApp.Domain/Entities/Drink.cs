namespace AutomatApp.Domain.Entities
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public List<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
