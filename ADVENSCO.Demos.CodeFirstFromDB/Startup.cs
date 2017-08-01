using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADVENSCO.Demos.CodeFirstFromDB.Startup))]
namespace ADVENSCO.Demos.CodeFirstFromDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
