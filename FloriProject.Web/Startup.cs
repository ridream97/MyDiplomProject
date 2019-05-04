using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FloriProject.Web.Startup))]
namespace FloriProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
