using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.Messaging;

namespace MyCQRS.Web.Auxiliary
{
    /// <summary>
    /// 是提供给应用层的
    /// </summary>
    public sealed class ServiceLocator
    {
        public static ICommandBus CommandBus { get; private set; }

        public static IEventBus EventBus { get; private set; }

        public static IMapper Mappers { get; private set; }

        public static IContainer Container { get; private set; }

        public static void Init(ContainerBuilder containerBuilder)
        {
            ContainerBootstrapper.BootstrapStructureMap(containerBuilder);
            Container = containerBuilder.Build();
            CommandBus = Container.Resolve<ICommandBus>();
            EventBus = Container.Resolve<IEventBus>();
            Mappers = Container.Resolve<IMapper>();
        }
    }
}