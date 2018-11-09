using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KLYNSBYS.Startup))]
namespace KLYNSBYS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
