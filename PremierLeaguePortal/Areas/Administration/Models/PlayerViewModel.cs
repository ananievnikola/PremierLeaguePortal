using PremierLeaguePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremierLeaguePortal.Areas.Administration.Models
{
    public class PlayerViewModel
    {
        //public Player Player { get; set; }
        //public Image Image { get; set; }
        public string Name { get; set; }
        public double ICTIndex { get; set; }
        public int BonusPoints { get; set; }
        //public string ImageDescription { get; set; }
    }
}