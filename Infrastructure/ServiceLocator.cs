﻿using Autofac;
using Messaging;
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



        static ServiceLocator()
        {
            ContainerBootstrapper.BootstrapStructureMap();

            using (var builder = new ContainerBuilder().Build())
            {

                CommandBus = builder.Resolve<ICommandBus>();

                EventBus = builder.Resolve<IEventBus>();
            }
        }
    }
}