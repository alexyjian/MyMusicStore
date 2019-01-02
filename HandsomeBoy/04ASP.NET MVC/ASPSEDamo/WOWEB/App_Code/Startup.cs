using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WOWEB.Startup))]
namespace WOWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
