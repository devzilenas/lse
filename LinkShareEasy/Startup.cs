using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkShareEasy.Startup))]
namespace LinkShareEasy
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
