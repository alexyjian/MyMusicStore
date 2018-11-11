using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_11._11Demo.Startup))]
namespace _11._11Demo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
