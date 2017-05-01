using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class Team : ModelBase
    {
        public virtual IList<Player> Players { get; set; }
        public string Name { get; set; }
        public Manager Manager { get; set; }
    }
}
