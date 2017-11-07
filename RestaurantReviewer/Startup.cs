using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestaurantReviewer.Startup))]
namespace RestaurantReviewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
