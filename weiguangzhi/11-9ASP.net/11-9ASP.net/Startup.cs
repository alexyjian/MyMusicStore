using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_11_9ASP.net.Startup))]
namespace _11_9ASP.net
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
