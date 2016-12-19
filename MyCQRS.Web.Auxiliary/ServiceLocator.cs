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
        public static readonly ServiceLocator Current;

        static ServiceLocator()
        {
            Current = new ServiceLocator();
        }

        public ICommandBus CommandBus { get; private set; }

        public IEventBus EventBus { get; private set; }

        public IMapper Mappers { get; private set; }

        public IContainer Container { get; private set; }

        public void Init(ContainerBuilder containerBuilder)
        {
            ContainerBootstrapper.BootstrapStructureMap(containerBuilder);
            Container = containerBuilder.Build();
            CommandBus = Container.Resolve<ICommandBus>();
            EventBus = Container.Resolve<IEventBus>();
            Mappers = Container.Resolve<IMapper>();
        }
    }
}