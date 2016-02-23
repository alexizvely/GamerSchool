using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(GameStore.Web.Startup))]

namespace GameStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
