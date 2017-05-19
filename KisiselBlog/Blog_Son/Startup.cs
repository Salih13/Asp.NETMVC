using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog_Son.Startup))]
namespace Blog_Son
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
