using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(GamerSchool.Web.Startup))]

namespace GamerSchool.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
