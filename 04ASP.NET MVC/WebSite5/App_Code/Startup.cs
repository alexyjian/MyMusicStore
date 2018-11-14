using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSite5.Startup))]
namespace WebSite5
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
