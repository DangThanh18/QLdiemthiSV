using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(de6.Startup))]
namespace de6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
