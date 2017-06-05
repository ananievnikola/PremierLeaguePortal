using PremierLeaguePortal.Context;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class BlogRepository : GenericRepository<Blog>
    {
        public BlogRepository(PremierLeagueContext context) : base(context)
        {

        }
    }
}