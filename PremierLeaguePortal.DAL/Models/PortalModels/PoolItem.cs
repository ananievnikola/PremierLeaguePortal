using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class PoolItem : ModelBase
    {
        /// <summary>
        /// The index of the actual answer
        /// </summary>
        public int Number { get; set; }
        public string Label { get; set; }
        /// <summary>
        /// the users who voted for this item, if any
        /// </summary>
        public virtual IList<ApplicationUser> VotedUsersForThisOption { get; set; }
    }
}
