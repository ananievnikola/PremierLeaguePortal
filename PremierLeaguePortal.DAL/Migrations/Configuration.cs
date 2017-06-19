namespace PremierLeaguePortal.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PremierLeaguePortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<PremierLeaguePortal.DAL.Context.PremierLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PremierLeaguePortal.DAL.Context.PremierLeagueContext context)
        {
            #region users
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

            var defaultAuthor = new ApplicationUser();
            defaultAuthor.Email = "defaultAuthor@gmail.com";
            defaultAuthor.UserName = "defaultAuthor@gmail.com";
            defaultAuthor.FirstName = "defaultAuthor";
            defaultAuthor.LastName = "defaultAuthor";
            defaultAuthor.NickName = "defaultAuthor";
            var defAuth = UserManager.Create(defaultAuthor, pass);

            if (defAuth.Succeeded)
            {
                var result1 = UserManager.AddToRole(nu3.Id, "Author");
            }

            #endregion

            #region blogs
            Blog b1 = new Blog()
            {
                ApplicationUser = user,
                Category = EBlogCategory.Analysis,
                Content = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,",
                CreatedOn = new DateTime(2017, 06, 01),
                Header = "Lorem ipsum",
                ModifiedOn = new DateTime(2017, 06, 01),
                SubHeader = "Lorem ipsum subheader"
            };
            context.Blogs.Add(b1);

            Blog b11 = new Blog()
            {
                ApplicationUser = user,
                Category = EBlogCategory.News,
                Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere",
                CreatedOn = new DateTime(2017, 06, 02),
                Header = "Cicero ",
                ModifiedOn = new DateTime(2017, 06, 03),
                SubHeader = "Cicero subheader"
            };
            context.Blogs.Add(b11);

            Blog b12 = new Blog()
            {
                ApplicationUser = user,
                Category = EBlogCategory.News,
                CreatedOn = new DateTime(2017, 06, 02),
                Content = "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles. Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que Occidental es.Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles.",
                Header = "Li Europan lingues",
                ModifiedOn = new DateTime(2017, 06, 03),
                SubHeader = "Li Europan lingues subheader"
            };
            context.Blogs.Add(b12);

            Blog b13 = new Blog()
            {
                ApplicationUser = user,
                Category = EBlogCategory.Transfers,
                CreatedOn = new DateTime(2017, 06, 05),
                Content = "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles. Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que Occidental es.Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles.",
                Header = "Transfer Li Europan lingues",
                ModifiedOn = new DateTime(2017, 06, 05),
                SubHeader = "Transfer Li Europan lingues subheader"
            };
            context.Blogs.Add(b13);
            Blog b2 = new Blog()
            {
                ApplicationUser = author,
                Category = EBlogCategory.Analysis,
                Content = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,",
                CreatedOn = new DateTime(2017, 06, 01),
                Header = "Lorem ipsum",
                ModifiedOn = new DateTime(2017, 06, 01),
                SubHeader = "Lorem ipsum subheader"
            };
            context.Blogs.Add(b2);
            Blog b21 = new Blog()
            {
                ApplicationUser = author,
                Category = EBlogCategory.News,
                Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere",
                CreatedOn = new DateTime(2017, 06, 02),
                Header = "Cicero ",
                ModifiedOn = new DateTime(2017, 06, 03),
                SubHeader = "Cicero subheader"
            };
            context.Blogs.Add(b21);
            Blog b22 = new Blog()
            {
                ApplicationUser = author,
                Category = EBlogCategory.News,
                CreatedOn = new DateTime(2017, 06, 02),
                Content = "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles. Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que Occidental es.Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles.",
                Header = "Li Europan lingues",
                ModifiedOn = new DateTime(2017, 06, 03),
                SubHeader = "Li Europan lingues subheader"
            };
            context.Blogs.Add(b22);
            Blog b23 = new Blog()
            {
                ApplicationUser = author,
                Category = EBlogCategory.Transfers,
                CreatedOn = new DateTime(2017, 06, 05),
                Content = "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles. Ma quande lingues coalesce, li grammatica del resultant lingue es plu simplic e regulari quam ti del coalescent lingues. Li nov lingua franca va esser plu simplic e regulari quam li existent Europan lingues. It va esser tam simplic quam Occidental in fact, it va esser Occidental. A un Angleso it va semblar un simplificat Angles, quam un skeptic Cambridge amico dit me que Occidental es.Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular. Li lingues differe solmen in li grammatica, li pronunciation e li plu commun vocabules. Omnicos directe al desirabilite de un nov lingua franca: On refusa continuar payar custosi traductores. At solmen va esser necessi far uniform grammatica, pronunciation e plu sommun paroles.",
                Header = "Transfer Li Europan lingues",
                ModifiedOn = new DateTime(2017, 06, 05),
                SubHeader = "Transfer Li Europan lingues subheader"
            };
            context.Blogs.Add(b23);
            Blog b3 = new Blog()
            {
                ApplicationUser = author2,
                Category = EBlogCategory.Analysis,
                Content = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,",
                CreatedOn = new DateTime(2017, 06, 01),
                Header = "Lorem ipsum",
                ModifiedOn = new DateTime(2017, 06, 01),
                SubHeader = "Lorem ipsum subheader"
            };
            context.Blogs.Add(b3);
            TrySaveChanges(context);
            //base.Seed(context);
            #endregion
        }

        private static int TrySaveChanges(PremierLeaguePortal.DAL.Context.PremierLeagueContext context)
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
