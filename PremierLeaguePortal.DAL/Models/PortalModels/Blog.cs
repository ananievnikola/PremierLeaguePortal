using System;

namespace PremierLeaguePortal.Models
{
    public class Blog : ModelBase
    {
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public string Content { get; set; }
        public EBlogCategory Category { get; set; }
        public virtual Image HeaderImage { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedOn { get; set; }
        public string Tags { get; set; }
    }
}