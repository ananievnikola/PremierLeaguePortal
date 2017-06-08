using PremierLeaguePortal.DAL.Context;
using PremierLeaguePortal.Models;

namespace PremierLeaguePortal.Repository
{
    public class BlogRepository : GenericRepository<Blog>
    {
        public BlogRepository(PremierLeagueContext context) : base(context)
        {

        }
    }
}