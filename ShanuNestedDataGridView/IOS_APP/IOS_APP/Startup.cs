using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOS_APP.Startup))]
namespace IOS_APP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
