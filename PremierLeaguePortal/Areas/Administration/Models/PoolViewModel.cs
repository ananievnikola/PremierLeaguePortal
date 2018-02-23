using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class PoolViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Заглавието трябва да бъде между 6 и 100 символа дълго.", MinimumLength = 6)]
        public string PoolName { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrentUserVoted { get; set; }
        public virtual IList<PoolItemViewModel> Items { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime ModifiedOn { get; set; }
        //Validation message for pool items
        public string PoolItemsValidationMessage { get; set; }
    }
}