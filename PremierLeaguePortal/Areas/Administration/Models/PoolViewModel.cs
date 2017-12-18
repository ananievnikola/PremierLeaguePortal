using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class PoolViewModel
    {
        public int Id { get; set; }
        public string PoolName { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrentUserVoted { get; set; }
        public virtual IList<PoolItem> Items { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}