using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class Pool : ModelBase
    {
        public string PoolName { get; set; }
        public bool IsActive { get; set; }
    }
}
