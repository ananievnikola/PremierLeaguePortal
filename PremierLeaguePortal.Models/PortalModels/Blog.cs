using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Models
{
    public class Blog : ModelBase
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Header { get; set; }
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string SubHeader { get; set; }
        [Required]
        public EBlogCategory Category { get; set; }
        //public string ImagePath { get; set; }
        public virtual Image HeaderImage { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual Author Autor { get; set; }
    }
}