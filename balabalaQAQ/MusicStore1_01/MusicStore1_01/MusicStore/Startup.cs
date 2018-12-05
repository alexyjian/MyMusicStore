using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicStore.Startup))]
namespace MusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
