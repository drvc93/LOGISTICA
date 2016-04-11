using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WSLogis.Startup))]
namespace WSLogis
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
