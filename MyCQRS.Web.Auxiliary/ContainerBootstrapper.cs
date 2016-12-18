using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.CommandHandlers;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.EventHandles;
using MyCQRS.Messaging;
using MyCQRS.Storage;
using MyCQRS.Utils;

namespace MyCQRS.Web.Auxiliary
{
    public static class ContainerBootstrapper
    {
        public static void BootstrapStructureMap(ContainerBuilder builder)
        {
    
            builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();
            // ReSharper disable once CoVariantArrayConversion
            builder.RegisterTypes(typeof(ICommandHandler<>).Assembly.DefinedTypes.Where(
                 s => s.GetInterfaces().Any(a => a.Name == typeof(ICommandHandler<>).Name)).ToArray());
            // ReSharper disable once CoVariantArrayConversion
            builder.RegisterTypes(typeof (IEventHandler<>).Assembly.DefinedTypes.Where(
                s => s.GetInterfaces().Any(a => a.Name == typeof (IEventHandler<>).Name)).ToArray());


            builder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();
            builder.RegisterType<CommandBus>().As<ICommandBus>();

            builder.RegisterType<ProcessBus>().As<IProcessBus>();
            builder.RegisterType<EventHandlerFactory>().As<IEventHandlerFactory>();
            builder.RegisterType<EventBus>().As<IEventBus>();
            builder.RegisterGeneric(typeof(Repositories<>)).As(typeof(IRepositories<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();



            builder.RegisterType<Mapper>().As<IMapper>();
 

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
