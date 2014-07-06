using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scrawler.Startup))]
namespace Scrawler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
