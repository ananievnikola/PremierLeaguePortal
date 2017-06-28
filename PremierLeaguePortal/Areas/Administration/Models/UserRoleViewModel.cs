using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        [DisplayName("Име")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        //public string NickName { get; set; }
    }
}