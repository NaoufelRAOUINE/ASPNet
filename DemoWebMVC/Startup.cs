using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoWebMVC.Startup))]
namespace DemoWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
