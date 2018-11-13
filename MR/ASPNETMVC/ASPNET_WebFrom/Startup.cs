using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspWeb.Startup))]
namespace aspWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
