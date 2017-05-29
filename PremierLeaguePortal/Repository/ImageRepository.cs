using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PremierLeaguePortal.Context;

namespace PremierLeaguePortal.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(PremierLeagueContext context) : base(context)
        {
        }

        //public override void Add(Image entity)
        //{
        //    base.Add(entity);
        //}
    }
}