using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOSTestApp.Startup))]
namespace IOSTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
