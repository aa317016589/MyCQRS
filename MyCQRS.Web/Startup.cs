using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyCQRS.Web.Startup))]

namespace MyCQRS.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
       
        }
    }
}
