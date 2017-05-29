using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        //void RemoveWithImage(Blog blog, Image image);
        //void AddWithImage(Blog blog, Image image);
    }
}