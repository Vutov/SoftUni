using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twitter.App.Startup))]
namespace Twitter.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
