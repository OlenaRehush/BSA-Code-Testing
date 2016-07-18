using System.Data.Entity.Migrations;
using Cashbox.DataAccess;
using Cashbox.Models;

namespace Cashbox.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CashboxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cashbox.DataAccess.CashboxDbContext";
        }

        protected override void Seed(CashboxDbContext context)
        {
            // Accounts
            context.Accounts.Add(new Account { Name = "Sheldon Cooper", Balance = 398.99m });
            context.Accounts.Add(new Account { Name = "Leopold the Cat", Balance = 17.12m });
            context.Accounts.Add(new Account { Name = "Jon Snow", Balance = 200m });

            context.Products.Add(new Product { Title = "Whiskas Junior Cat Food Chicken", Price = 7.45m, Amount = 11 });
            context.Products.Add(new Product { Title = "Lego Star Wars", Price = 16.99m, Amount = 2 });
            context.Products.Add(new Product { Title = "Logitech Mouse G602", Price = 79.99m, Amount = 3 });
            context.Products.Add(new Product { Title = "Lego Mindstorms EV3", Price = 349.99m, Amount = 1 });
            context.Products.Add(new Product { Title = "Arduino UNO R3 with DIP ATmega328P", Price = 25.95m, Amount = 2 });
            context.Products.Add(new Product { Title = "Damascus Steel Katana 4096 Layers", Price = 179.99m, Amount = 1 });
        }
    }
}
