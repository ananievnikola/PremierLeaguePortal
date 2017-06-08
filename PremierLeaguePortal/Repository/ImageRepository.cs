using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class ImageRepository : GenericRepository<Image>
    {
        public ImageRepository(PremierLeagueContext context) : base(context)
        {

        }
    }
}