using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Messaging;
using MyCQRS.Messaging;

namespace MyCQRS.Web.Auxiliary
{
   public static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandBus>().As<ICommandBus>();

            builder.RegisterType<EventBus>().As<IEventBus>();
 

            //builder.RegisterType<IEventBus>()
            //au.Initialize(x =>
            //{
            //    x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
            //    x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
            //    x.For<IEventBus>().Use<EventBus>();
            //    x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
            //    x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
            //    x.For<ICommandBus>().Use<CommandBus>();
            //    x.For<IEventBus>().Use<EventBus>();
            //    x.For<IReportDatabase>().Use<ReportDatabase>();
            //});
        }
    }
}
 