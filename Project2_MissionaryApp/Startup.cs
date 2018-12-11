using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project2_MissionaryApp.Startup))]
namespace Project2_MissionaryApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
