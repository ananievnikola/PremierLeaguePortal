using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public string Content { get; set; }
        public EBlogCategory Category { get; set; }
        public Image HeaderImage { get; set; }
        //public DateTime ModifiedOn { get; set; }
        //public string AuthorName { get; set; }
        //public string AuthorNickName { get; set; }
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
    }
}