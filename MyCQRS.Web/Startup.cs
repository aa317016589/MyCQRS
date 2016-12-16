using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using MyCQRS.Web.Auxiliary;
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
