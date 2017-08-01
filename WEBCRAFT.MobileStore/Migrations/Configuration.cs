namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WEBCRAFT.MobileStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WEBCRAFT.MobileStore.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.AccountTypes.AddOrUpdate(
                at => at.Name, 
                new AccountType { Name = "Sales" },
                new AccountType { Name = "Purchases" },
                new AccountType { Name = "Customers" },
                new AccountType { Name="Expenses"}
            );
            context.Accounts.AddOrUpdate(
                new Account { Name = "Sales" },
                new Account { Name = "Purchases" },
                new Account { Name = "Customers" },
                new Account { Name = "Expenses" }
                );
        }
    }
}
