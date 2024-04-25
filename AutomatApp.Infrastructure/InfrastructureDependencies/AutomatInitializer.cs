using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using AutomatApp.Domain.Entities;

namespace AutomatApp.Infrastructure.InfrastructureDependencies
{
    public static class AutomatInitializer
    {
        public async static Task<WebApplication> SeedAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<AutomatDbContext>();

                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    var fanta = new Drink
                    {
                        Id = 1,
                        Name = "Fanta",
                        Price = 120
                    };

                    var cocaCola = new Drink
                    {
                        Id = 2,
                        Name = "CocaCola",
                        Price = 130
                    };

                    var sprite = new Drink
                    {
                        Id = 3,
                        Name = "Sprite",
                        Price = 115
                    };

                    var coin1 = new Coin
                    {
                        Id = 1,
                        Price = 1
                    };

                    var coin2 = new Coin
                    {
                        Id = 2,
                        Price = 2
                    };

                    var coin3 = new Coin
                    {
                        Id = 3,
                        Price = 5
                    };

                    var coin4 = new Coin
                    {
                        Id = 4,
                        Price = 10
                    };

                    var evgenyClient = new Client
                    {
                        Id = 1,
                        FirstName = "Евгений",
                        LastName = "Морозов",
                        Login = "Evgeny"
                    };

                    var evgenyAdmin = new Administrator
                    {
                        ClientId = evgenyClient.Id,
                        Password = "Password"
                    };

                    var vladimirClient = new Client
                    {
                        Id = 2,
                        FirstName = "Владимир",
                        LastName = "Сапронов",
                        Login = "Vladimir"
                    };

                    var vladimirAdmin = new Administrator
                    {
                        ClientId = vladimirClient.Id,
                        Password = "Password"
                    };

                    var nicolaiClient = new Client
                    {
                        Id = 3,
                        FirstName = "Николай",
                        LastName = "Плохотнюк",
                        Login = "Nicolai"
                    };

                    var walletEvgeny = new Wallet
                    {
                        Id = 1,
                        ClientId = evgenyAdmin.Client.Id,
                        TotalPrice = 2350
                    };

                    var coinCaseEvgeny1 = new CoinCase
                    {
                        Id = 1,
                        Count = 500,
                        CoinId = coin1.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var coinCaseEvgeny2 = new CoinCase
                    {
                        Id = 2,
                        Count = 300,
                        CoinId = coin2.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var coinCaseEvgeny3 = new CoinCase
                    {
                        Id = 3,
                        Count = 150,
                        CoinId = coin3.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var coinCaseEvgeny4 = new CoinCase
                    {
                        Id = 4,
                        Count = 50,
                        CoinId = coin4.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var walletVladimir = new Wallet
                    {
                        Id = 2,
                        ClientId = vladimirAdmin.Client.Id,
                        TotalPrice = 2350
                    };

                    var coinCaseVladimir1 = new CoinCase
                    {
                        Id = 5,
                        Count = 500,
                        CoinId = coin1.Id,
                        WalletId = walletVladimir.Id
                    };

                    var coinCaseVladimir2 = new CoinCase
                    {
                        Id = 6,
                        Count = 300,
                        CoinId = coin2.Id,
                        WalletId = walletVladimir.Id
                    };

                    var coinCaseVladimir3 = new CoinCase
                    {
                        Id = 7,
                        Count = 150,
                        CoinId = coin3.Id,
                        WalletId = walletVladimir.Id
                    };

                    var coinCaseVladimir4 = new CoinCase
                    {
                        Id = 8,
                        Count = 50,
                        CoinId = coin4.Id,
                        WalletId = walletVladimir.Id
                    };

                    var walletNicolai = new Wallet
                    {
                        Id = 3,
                        ClientId = nicolaiClient.Id,
                        TotalPrice = 2350
                    };

                    var coinCaseNicolai1 = new CoinCase
                    {
                        Id = 9,
                        Count = 500,
                        CoinId = coin1.Id,
                        WalletId = walletNicolai.Id
                    };

                    var coinCaseNicolai2 = new CoinCase
                    {
                        Id = 10,
                        Count = 300,
                        CoinId = coin1.Id,
                        WalletId = walletNicolai.Id
                    };

                    var coinCaseNicolai3 = new CoinCase
                    {
                        Id = 11,
                        Count = 150,
                        CoinId = coin1.Id,
                        WalletId = walletNicolai.Id
                    };

                    var coinCaseNicolai4 = new CoinCase
                    {
                        Id = 12,
                        Count = 50,
                        CoinId = coin1.Id,
                        WalletId = walletNicolai.Id
                    };

                    var ShoppingCartEvgenyFanta = new ShoppingCart
                    {
                        Id = 1,
                        Count = 0,
                        DrinkId = fanta.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var ShoppingCartEvgenyCocaCola = new ShoppingCart
                    {
                        Id = 2,
                        Count = 0,
                        DrinkId = cocaCola.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var ShoppingCartEvgenySprite = new ShoppingCart
                    {
                        Id = 3,
                        Count = 0,
                        DrinkId = sprite.Id,
                        WalletId = walletEvgeny.Id
                    };

                    var ShoppingCartVladimirFanta = new ShoppingCart
                    {
                        Id = 4,
                        Count = 0,
                        DrinkId = fanta.Id,
                        WalletId = walletVladimir.Id
                    };

                    var ShoppingCartVladimirCocaCola = new ShoppingCart
                    {
                        Id = 5,
                        Count = 0,
                        DrinkId = cocaCola.Id,
                        WalletId = walletVladimir.Id
                    };

                    var ShoppingCartVladimirSprite = new ShoppingCart
                    {
                        Id = 6,
                        Count = 0,
                        DrinkId = sprite.Id,
                        WalletId = walletVladimir.Id
                    };

                    var ShoppingCartNicolaiFanta = new ShoppingCart
                    {
                        Id = 7,
                        Count = 0,
                        DrinkId = fanta.Id,
                        WalletId = walletNicolai.Id
                    };

                    var ShoppingCartNicolaiCocaCola = new ShoppingCart
                    {
                        Id = 8,
                        Count = 0,
                        DrinkId = cocaCola.Id,
                        WalletId = walletNicolai.Id
                    };

                    var ShoppingCartNicolaiSprite = new ShoppingCart
                    {
                        Id = 9,
                        Count = 0,
                        DrinkId = sprite.Id,
                        WalletId = walletNicolai.Id
                    };

                    await context.Drinks.AddRangeAsync(fanta, cocaCola, sprite);
                    await context.Coins.AddRangeAsync(coin1, coin2, coin3, coin3, coin4);
                    await context.Clients.AddRangeAsync(evgenyClient, vladimirClient, nicolaiClient);
                    await context.Administrators.AddRangeAsync(evgenyAdmin, vladimirAdmin);
                    await context.Wallets.AddRangeAsync(walletEvgeny, walletVladimir, walletNicolai);
                    await context.CoinCases.AddRangeAsync(coinCaseEvgeny1, coinCaseEvgeny2, coinCaseEvgeny3, coinCaseEvgeny4,
                        coinCaseVladimir1, coinCaseVladimir2, coinCaseVladimir3, coinCaseVladimir4,
                        coinCaseNicolai1, coinCaseNicolai2, coinCaseNicolai3, coinCaseNicolai4);
                    await context.ShoppingCarts.AddRangeAsync(ShoppingCartEvgenyFanta, ShoppingCartEvgenyCocaCola, ShoppingCartEvgenySprite,
                        ShoppingCartVladimirFanta, ShoppingCartVladimirCocaCola, ShoppingCartVladimirSprite,
                        ShoppingCartNicolaiFanta, ShoppingCartNicolaiCocaCola, ShoppingCartNicolaiSprite);

                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                }
                return app;
            }
        }
    }
}