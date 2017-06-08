﻿using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using System.Collections.Generic;
using System.Linq;

namespace PremierLeaguePortal.Repository
{
    public class BlogRepository : GenericRepository<Blog>
    {
        public BlogRepository(PremierLeagueContext context) : base(context)
        {

        }

        public IEnumerable<Blog> GetAllByUser(string userId)
        {
            return _Context.Blogs.Where(b => b.ApplicationUser.Id == userId);
        }
        public Blog GetByUser(string userId, int id)
        {
            return _Context.Blogs.FirstOrDefault(b => b.ApplicationUser.Id == userId && b.Id == id);
        }
    }
}