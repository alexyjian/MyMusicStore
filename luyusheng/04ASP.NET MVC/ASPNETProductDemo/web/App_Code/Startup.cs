using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web.Startup))]
namespace web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
