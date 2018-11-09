using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KLYNDEMO.Startup))]
namespace KLYNDEMO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
