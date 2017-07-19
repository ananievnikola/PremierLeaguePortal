using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PremierLeaguePortal.DAL.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

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

        public IEnumerable<ApplicationUser> GetUsersNotInRole(string roleName)
        {
            var role = _Context.Roles.SingleOrDefault(m => m.Name == roleName);
            var usersNotInRole = _Context.Users.Where(m => m.Roles.All(r => r.RoleId != role.Id)).ToList();
            return usersNotInRole;
        }

        public void AddUserToRole(string userId, string roleName)
        {
            var user = GetById(userId);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            UserManager.AddToRole(user.Id, roleName);
        }

        public void RemoveUserFromRole(string userId, string roleName)
        {
            var user = GetById(userId);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            UserManager.RemoveFromRole(userId, roleName);
        }

        public List<string> GetUserRoles(string userId)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            return UserManager.GetRoles(userId).ToList();
        }

        public void Delete(string userId)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_Context));
            UserManager.Delete(_Context.Users.FirstOrDefault(u => u.Id == userId));
        }
    }
}