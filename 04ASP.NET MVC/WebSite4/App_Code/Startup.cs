using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite4.Startup))]
namespace WebSite4
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
