using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TlcMvc.Startup))]
namespace TlcMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
