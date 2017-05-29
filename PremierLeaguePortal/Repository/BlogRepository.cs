using PremierLeaguePortal.Context;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(PremierLeagueContext context) : base(context)
        {

        }

        //public void AddWithImage(Blog blog, Image image)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveWithImage(Blog blog, Image image)
        //{
        //    throw new NotImplementedException();
        //}
    }
}