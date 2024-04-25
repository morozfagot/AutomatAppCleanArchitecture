using System;
using System.Collections;
using System.Collections.Generic;
namespace AutomatApp.Domain.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int DrinkId { get; set; }
        public Drink? Drink { get; set; }
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
