using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MyCQRS.ApplicationHelper;
using MyCQRS.Web.Auxiliary;

namespace MyCQRS.Web
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            ServiceLocator.Current.Init(builder);            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(ServiceLocator.Current.Container));
            Duplicate.Create(ServiceLocator.Current.Container);
        }
    }
}