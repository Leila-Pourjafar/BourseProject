using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bourse.Startup))]
namespace Bourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
