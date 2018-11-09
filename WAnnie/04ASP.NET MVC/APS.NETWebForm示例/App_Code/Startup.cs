using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APS.NETWebForm示例.Startup))]
namespace APS.NETWebForm示例
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
