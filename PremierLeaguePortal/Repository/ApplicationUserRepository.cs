using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PremierLeaguePortal.DAL.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PremierLeaguePortal.Repository
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>
    {
        public ApplicationUserRepository(PremierLeagueContext context) : base(context)
        {
        }

        public ApplicationUser GetById(string id)
        {
            return _Context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetUsersInRole(string roleName)
        {
            var role = _Context.Roles.FirstOrDefault(r => r.Name == roleName);
            return _Context.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id)).ToList(); //FirstOrDefault(u => u.Id == id);
        }

        public void AddUserToRole(string userId, string roleName)
        {
            var user = GetById(userId);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            //UserManager.RemoveFromRole(userId, roleName);
            UserManager.AddToRole(user.Id, roleName);
        }

        public void RemoveUserFromRole(string userId, string roleName)
        {
            var user = GetById(userId);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            UserManager.RemoveFromRole(userId, roleName);
            //UserManager.AddToRole(user.Id, roleName);
        }
    }
}