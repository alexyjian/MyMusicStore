using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcDemo1.Startup))]
namespace MvcDemo1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
