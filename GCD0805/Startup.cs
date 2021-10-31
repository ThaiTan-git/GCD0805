using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0805.Startup))]
namespace GCD0805
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
