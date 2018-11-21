using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_11._11.Startup))]
namespace _11._11
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
