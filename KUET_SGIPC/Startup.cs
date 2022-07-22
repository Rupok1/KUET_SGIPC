using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KUET_SGIPC.Startup))]
namespace KUET_SGIPC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
