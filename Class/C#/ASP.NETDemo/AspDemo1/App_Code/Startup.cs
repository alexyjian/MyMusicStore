using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspDemo.Startup))]
namespace AspDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
