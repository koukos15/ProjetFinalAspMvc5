using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaffeGest.Startup))]
namespace CaffeGest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
