using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP.ENTWebForm.Startup))]
namespace ASP.ENTWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
