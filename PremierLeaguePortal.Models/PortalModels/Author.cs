using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeaguePortal.Models
{
    public class Author : ModelBase
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool IsApproved { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
