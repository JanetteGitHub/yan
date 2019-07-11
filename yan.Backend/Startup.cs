using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yan.Backend.Startup))]
namespace yan.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
