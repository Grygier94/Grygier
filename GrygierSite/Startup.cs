using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrygierSite.Startup))]
namespace GrygierSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
