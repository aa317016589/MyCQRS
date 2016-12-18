using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MyCQRS.Web.Auxiliary;

namespace MyCQRS.Web
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            ServiceLocator.Init(builder);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}