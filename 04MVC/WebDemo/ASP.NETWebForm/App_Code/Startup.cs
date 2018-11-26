using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDemo.Startup))]
namespace WebDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
