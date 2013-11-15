using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingGuide.Startup))]
namespace ShoppingGuide
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
