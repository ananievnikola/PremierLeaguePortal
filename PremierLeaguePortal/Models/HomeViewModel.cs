using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Models
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public string Content { get; set; }
        public EBlogCategory Category { get; set; }
        public Image HeaderImage { get; set; }
        public HttpPostedFileBase HeaderImageFile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsPublished { get; set; }
        public string ShortContent
        {
            get
            {
                if (Content.Length > 17)
                {
                    return Content.Substring(0, 17) + "...";
                }
                return Content;
            }
        }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}