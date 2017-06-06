using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBCRAFT.MobileStore.Startup))]
namespace WEBCRAFT.MobileStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
