using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS练习区.Startup))]
namespace VS练习区
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
