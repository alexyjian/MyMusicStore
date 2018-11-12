using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Desktop.Startup))]
namespace Desktop
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
