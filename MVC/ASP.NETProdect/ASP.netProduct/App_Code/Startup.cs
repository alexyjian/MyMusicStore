using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.netProduct.Startup))]
namespace ASP.netProduct
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
