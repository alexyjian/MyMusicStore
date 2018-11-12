using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_11_12WEB商品.Startup))]
namespace _11_12WEB商品
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
