using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Skidly.Startup))]
namespace Skidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
