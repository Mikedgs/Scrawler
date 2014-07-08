using Microsoft.Owin;
using Owin;
using Scrawler;

[assembly: OwinStartup(typeof (Startup))]

namespace Scrawler
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}