using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsgD2._2.Startup))]
namespace AsgD2._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
