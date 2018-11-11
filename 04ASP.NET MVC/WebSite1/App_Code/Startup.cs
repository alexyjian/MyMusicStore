using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite1.Startup))]
namespace WebSite1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
