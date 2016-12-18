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
using MyCQRS.Storage;
using MyCQRS.Web.Auxiliary;

namespace TestXC
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<Type> types = typeof (ICommandHandler<>).Assembly.DefinedTypes.Where(s=>s.GetInterfaces().Any(a=>a.Name == typeof(ICommandHandler<>).Name));

            //foreach (var type in types)
            //{
            //    Console.WriteLine(type.Name);
            //}

            //Console.ReadKey();

            //return;



            var builder = new ContainerBuilder();
            //builder.RegisterType(typeof(AggregateRoot));
            
            builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();
            builder.RegisterTypes(
                typeof (ICommandHandler<>).Assembly.DefinedTypes.Where(
                    s => s.GetInterfaces().Any(a => a.Name == typeof (ICommandHandler<>).Name)).ToArray());

        


            //builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            //builder.RegisterType<EventRepository<PostAggregate>>().As<IEventRepository<PostAggregate>>();
            //builder.RegisterType<PostAddCommandHandler>().PropertiesAutowired();


            //builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();



            using (var  b = builder.Build())
            {
                b.Resolve(typeof(PostAddCommandHandler));
            }

        

            Console.ReadKey();
        }
    }
}
