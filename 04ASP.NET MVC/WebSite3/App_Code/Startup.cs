using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite3.Startup))]
namespace WebSite3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
