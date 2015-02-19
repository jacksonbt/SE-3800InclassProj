using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SE_3800InclassProj.Startup))]
namespace SE_3800InclassProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
