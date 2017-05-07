namespace AutomatedTellerMachine.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AutomatedTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(AutomatedTellerMachine.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            ////context.Users.AddOrUpdate

            if (!context.Users.Any(t => t.UserName == "admin@mvcatm.com"))
            {
                var user = new ApplicationUser { UserName = "admin@mvcatm.com", Email = "admin@mvcatm.com" };
                userManager.Create(user, "Jajko123_");

                var service = new CheckingAccountService(context);
                service.CreateCheckingAccount("admin", "user", user.Id, 1000);

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }

            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 100, CheckingAccountId = 3 });
            context.Transactions.Add(new Transaction { Amount = 200, CheckingAccountId = 3 });

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
        }
    }
}
