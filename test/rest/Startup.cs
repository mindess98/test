using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rest.Startup))]
namespace rest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
