using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class TeamOfTheWeek : ModelBase
    {
        public virtual IList<Player> Players { get; set; }
    }
}
