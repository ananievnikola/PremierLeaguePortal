using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class UserRoleViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public bool isAuthor { get; set; }
    }
}