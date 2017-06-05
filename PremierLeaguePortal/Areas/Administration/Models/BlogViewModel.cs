﻿using PremierLeaguePortal.Models;
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
        //public DateTime ModifiedOn { get; set; }
        //public string AuthorName { get; set; }
        //public string AuthorNickName { get; set; }
        public HttpPostedFileBase HeaderImageFile { get; set; }
    }
}