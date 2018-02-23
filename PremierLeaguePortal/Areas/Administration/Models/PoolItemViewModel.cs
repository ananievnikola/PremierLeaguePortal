using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class PoolItemViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [StringLength(100, ErrorMessage = "Името на опцията трябва да бъде между 3 и 100 символа дълго.", MinimumLength = 3)]
        public string Label { get; set; }
        public virtual IList<ApplicationUser> VotedUsersForThisOption { get; set; }
    }
}