namespace PremierLeaguePortal.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
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

            var author = new ApplicationUser();
            author.Email = "author@gmail.com";
            author.UserName = "author@gmail.com";
            author.FirstName = "Author";
            author.LastName = "Test";
            author.NickName = "TheAuthor";
            var authorUser = UserManager.Create(author, pass);

            if (authorUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(author.Id, "Author");
            }

            var author2 = new ApplicationUser();
            author2.Email = "author2@gmail.com";
            author2.UserName = "author2@gmail.com";
            author2.FirstName = "Author2";
            author2.LastName = "Test2";
            author2.NickName = "TheAuthor2";
            var authorUser2 = UserManager.Create(author2, pass);

            if (authorUser2.Succeeded)
            {
                var result1 = UserManager.AddToRole(author2.Id, "Author");
            }

            var nu1 = new ApplicationUser();
            nu1.Email = "normaluser1@gmail.com";
            nu1.UserName = "normaluser1@gmail.com";
            nu1.FirstName = "normaluser1";
            nu1.LastName = "normaluser1";
            nu1.NickName = "normaluser1";
            var normaluser1 = UserManager.Create(nu1, pass);

            if (normaluser1.Succeeded)
            {
                var result1 = UserManager.AddToRole(nu1.Id, "NormalUser");
            }

            var nu2 = new ApplicationUser();
            nu2.Email = "normaluser2@gmail.com";
            nu2.UserName = "normaluser2@gmail.com";
            nu2.FirstName = "normaluser2";
            nu2.LastName = "normaluser2";
            nu2.NickName = "normaluser2";
            var normaluser2 = UserManager.Create(nu2, pass);

            if (normaluser2.Succeeded)
            {
                var result1 = UserManager.AddToRole(nu2.Id, "NormalUser");
            }

            var nu3 = new ApplicationUser();
            nu3.Email = "normaluser3@gmail.com";
            nu3.UserName = "normaluser3@gmail.com";
            nu3.FirstName = "normaluser3";
            nu3.LastName = "normaluser3";
            nu3.NickName = "normaluser3";
            var normaluser3 = UserManager.Create(nu3, pass);

            if (normaluser3.Succeeded)
            {
                var result1 = UserManager.AddToRole(nu3.Id, "NormalUser");
            }
        }
    }
}
