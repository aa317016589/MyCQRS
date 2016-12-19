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

        public static void Init(ContainerBuilder containerBuilder)
        {
            ContainerBootstrapper.BootstrapStructureMap(containerBuilder);

            var builder = containerBuilder.Build();

            Duplicate.Create(builder);

            CommandBus = builder.Resolve<ICommandBus>();
            EventBus = builder.Resolve<IEventBus>();
            Mappers = builder.Resolve<IMapper>();

        }
    }
}