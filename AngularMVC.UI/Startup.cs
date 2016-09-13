using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularMVC.UI.Startup))]
namespace AngularMVC.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
