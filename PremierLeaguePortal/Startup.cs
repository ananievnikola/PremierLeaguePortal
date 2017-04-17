using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PremierLeaguePortal.Startup))]
namespace PremierLeaguePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
