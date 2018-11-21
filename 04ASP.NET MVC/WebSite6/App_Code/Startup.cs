using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite6.Startup))]
namespace WebSite6
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
