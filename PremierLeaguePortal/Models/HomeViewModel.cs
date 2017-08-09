using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public string CategoryText {
            get
            {
                string cat = "Категория: ";
                switch (Category)
                {
                    case EBlogCategory.Analysis:
                        return cat + "Анализи";
                    case EBlogCategory.Transfers:
                        return cat + "Трансфери";
                    case EBlogCategory.News:
                        return cat + "Новини";
                    default:
                        return cat + "Други";
                }
            }
        }
        public Image HeaderImage { get; set; }
        public HttpPostedFileBase HeaderImageFile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? PublishedOn { get; set; }
        public bool IsPublished { get; set; }

        public string PreviewContent
        {
            get
            {
                string content = Regex.Replace(Content, "<.*?>", String.Empty);
                if (content.Length > 300)
                {
                    return content.Substring(0, 300) + "...";
                }
                return content;
            }
        }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public bool isPublish { get; set; }
        public string ViewTitle {
            get
            {
                if (this.Category == EBlogCategory.Analysis)
                {
                    return "Анализи";
                }
                else if (this.Category == EBlogCategory.News)
                {
                    return "Новини";
                }
                else if (this.Category == EBlogCategory.Transfers)
                {
                    return "Трансфери";
                }
                return string.Empty;
            }
        }
        public List<Blog> OthersInCategory
        {
            get;set;
        }
    }
}