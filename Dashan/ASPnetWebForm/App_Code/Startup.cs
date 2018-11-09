using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPnetWebForm.Startup))]
namespace ASPnetWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
