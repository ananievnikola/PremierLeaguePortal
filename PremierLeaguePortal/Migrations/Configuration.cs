namespace PremierLeaguePortal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PremierLeaguePortal.DAL.Context;
    using PremierLeaguePortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PremierLeaguePortal.DAL.Context.PremierLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PremierLeaguePortal.DAL.Context.PremierLeagueContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new PremierLeagueContext()));
            roleManager.Create(new IdentityRole("SuperUser"));
            roleManager.Create(new IdentityRole("Author"));
            roleManager.Create(new IdentityRole("NormalUser"));

            var user = new ApplicationUser();
            user.Email = "ananievnikola@gmail.com";
            user.UserName = "ananievnikola@gmail.com";
            user.FirstName = "Nikola";
            user.LastName = "Ananiev";
            user.NickName = "Shamana";
            string pass = "1qaz@WSX";
            var chkUser = UserManager.Create(user, pass);

            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "SuperUser");
            }
        }
    }
}
