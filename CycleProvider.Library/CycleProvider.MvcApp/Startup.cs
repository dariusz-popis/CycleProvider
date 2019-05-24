using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CycleProvider.MvcApp.Startup))]
namespace CycleProvider.MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
