using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Repository
{
    public class PoolItemRepository : GenericRepository<PoolItem>
    {
        public PoolItemRepository(PremierLeagueContext context) : base(context)
        {

        }
    }
}