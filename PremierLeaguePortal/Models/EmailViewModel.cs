using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Models
{
    public class EmailViewModel
    {
        [Required, Display(Name = "Име")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Съобщение")]
        public string Message { get; set; }
        [Required, Display(Name = "Тема")]
        public string Subject { get; set; }
    }
}