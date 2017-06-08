using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PremierLeaguePortal.DAL.Context;

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
    }
}