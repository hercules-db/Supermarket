using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Supermarket.Startup))]
namespace Supermarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
