using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidemliUzman.Startup))]
namespace KidemliUzman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
