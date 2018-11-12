using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPSWEB.Startup))]
namespace ASPSWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
