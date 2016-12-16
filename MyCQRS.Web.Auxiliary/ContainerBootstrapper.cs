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
using MyCQRS.Messaging;
using MyCQRS.Storage;
using MyCQRS.Utils;

namespace MyCQRS.Web.Auxiliary
{
    public static class ContainerBootstrapper
    {
        public static ContainerBuilder BootstrapStructureMap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>();
            builder.RegisterType<CommandBus>().As<ICommandBus>();

            builder.RegisterType<ProcessBus>().As<IProcessBus>();
            builder.RegisterType<EventHandlerFactory>().As<IEventHandlerFactory>();
            builder.RegisterType<EventBus>().As<IEventBus>();
            builder.RegisterGeneric(typeof(Repositories<>)).As(typeof(IRepositories<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<PostAddCommand>().InstancePerLifetimeScope();


            //builder.RegisterInstance(typeof(ICommand));
            builder.RegisterInstance(typeof(AggregateRoot));
            //builder.RegisterInstance(typeof(ICommandHandler<>));
            builder.RegisterType<PostAddCommandHandler>();
            //builder.RegisterType<PostAddCommandHandler>().As(typeof(ICommandHandler<PostAddCommand>)).InstancePerLifetimeScope();

            var f = builder.Build();


             builder.RegisterType<Mapper>().As<IMapper>();

            return builder;

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
