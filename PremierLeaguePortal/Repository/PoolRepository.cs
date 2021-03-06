﻿using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PremierLeaguePortal.DAL.Context;

namespace PremierLeaguePortal.Repository
{
    public class PoolRepository : GenericRepository<Pool>
    {
        public PoolRepository(PremierLeagueContext context) : base(context)
        {
            
        }

        public IEnumerable<Pool> GetAllActive()
        {
            return _Context.Pools
                .Include("Items")
                .Where(p => p.IsActive);
        }
    }
}