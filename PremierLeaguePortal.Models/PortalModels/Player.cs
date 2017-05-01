using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class Player : ModelBase
    {
        public string Name { get; set; }
        public double ICTIndex { get; set; }
        public int BonusPoints { get; set; }
        public virtual Image Image { get; set; }
    }
}
