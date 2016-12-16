using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.CommandHandlers;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Storage;
using MyCQRS.Web.Auxiliary;

namespace TestXC
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(PostAggregate));
            builder.RegisterType<InMemoryEventStorage>().As<IEventStorage>();
            builder.RegisterType<EventRepository<PostAggregate>>().As<IEventRepository<PostAggregate>>();
            builder.RegisterType<PostAddCommandHandler>().PropertiesAutowired();


            //builder.RegisterGeneric(typeof(EventRepository<>)).As(typeof(IEventRepository<>)).InstancePerLifetimeScope();
          


            using (var  b = builder.Build())
            {
                b.Resolve(typeof(IEventRepository<PostAggregate>));
            }

        

            Console.ReadKey();
        }
    }
}
