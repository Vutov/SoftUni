using Microsoft.Owin;
using Restaurants.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace Restaurants.Services
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
