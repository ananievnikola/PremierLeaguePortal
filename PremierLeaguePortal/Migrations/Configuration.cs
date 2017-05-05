namespace PremierLeaguePortal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PremierLeaguePortal.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PremierLeaguePortal.Context.PremierLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PremierLeaguePortal.Context.PremierLeagueContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new PremierLeagueContext())
                );
            roleManager.Create(new IdentityRole("SuperUser"));
            roleManager.Create(new IdentityRole("Author"));
            roleManager.Create(new IdentityRole("NormalUser"));
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
