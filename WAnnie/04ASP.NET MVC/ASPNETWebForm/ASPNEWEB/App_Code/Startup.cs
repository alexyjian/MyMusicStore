using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNEWEB.Startup))]
namespace ASPNEWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
