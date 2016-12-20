using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.CommandHandlers;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;
using MyCQRS.EventHandles;
using MyCQRS.Messaging;
using MyCQRS.ProcessManagers;
using MyCQRS.Storage;
using MyCQRS.Utils;
using MyCQRS.Web.Auxiliary;

namespace TestXC
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType(typeof(AggregateRoot));

            builder.RegisterType<EventHandlerFactory>().As<IEventHandlerFactory>();
            builder.RegisterType<ProcessFactory>().As<IProcessFactory>();
            builder.RegisterType<EventBus>().As<IEventBus>();
            builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();
            // ReSharper disable once CoVariantArrayConversion
            builder.RegisterTypes(
                typeof(ICommandHandler<>).Assembly.DefinedTypes.Where(
                    s => s.GetInterfaces().Any(a => a.Name == typeof(ICommandHandler<>).Name)).ToArray());


            builder.RegisterGeneric(typeof(Repositories<>)).As(typeof(IRepositories<>)).InstancePerLifetimeScope();
            // ReSharper disable once CoVariantArrayConversion
            builder.RegisterTypes(typeof(IEventHandler<>).Assembly.DefinedTypes.Where(
                s => s.GetInterfaces().Any(a => a.Name == typeof(IEventHandler<>).Name)).ToArray());

            //builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            //builder.RegisterType<EventRepository<PostAggregate>>().As<IEventRepository<PostAggregate>>();
            //builder.RegisterType<PostAddCommandHandler>().PropertiesAutowired();


            //builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();



            using (var  b = builder.Build())
            {
                b.Resolve(typeof(PostAddEventHandle));
            }

        

            Console.ReadKey();
        }
    }
}
