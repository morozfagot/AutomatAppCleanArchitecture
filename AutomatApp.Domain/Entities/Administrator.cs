namespace AutomatApp.Domain.Entities
{
    public class Administrator
    {
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
