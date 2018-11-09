using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APSWebFormdemo.Startup))]
namespace APSWebFormdemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
