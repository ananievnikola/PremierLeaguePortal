﻿using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DisplayName("Заглавие")]
        public string Header { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DisplayName("Подзаглавие")]
        public string SubHeader { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Required]
        [StringLength(20000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 200)]
        [DisplayName("Съдържание")]
        public string Content { get; set; }
        [Required]
        [DisplayName("Категория")]
        public EBlogCategory Category { get; set; }
        [DisplayName("Заглавна снимка")]
        public Image HeaderImage { get; set; }
        [DisplayName("Качете заглавна снимка")]
        public HttpPostedFileBase HeaderImageFile { get; set; }
        [DisplayName("Създанен на")]
        public DateTime? CreatedOn { get; set; }
        [DisplayName("Променен на")]
        public DateTime? ModifiedOn { get; set; }
        [DisplayName("Публикуван на")]
        public DateTime? PublishedOn { get; set; }
        [DisplayName("Публикуван")]
        public bool IsPublished { get; set; }
        [DisplayName("Съкратено съдържание")]
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