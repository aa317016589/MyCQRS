using System;
using System.Collections.Generic;
using System.Linq;
using MyCQRS.ApplicationHelper;
using MyCQRS.CommandHandlers;
using MyCQRS.Commands;

namespace MyCQRS.Utils
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>();
            var cmdHandle = handlers.Select(h => Duplicate.Instance.Resolve<ICommandHandler<T>>(h)).FirstOrDefault();

            return cmdHandle;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            return
                typeof (ICommandHandler<>).Assembly.GetExportedTypes()
                    .Where(
                        x =>
                            x.GetInterfaces()
                                .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof (ICommandHandler<>)))
                    .Where(h => h.GetInterfaces().Any(a => a.GetGenericArguments().Any(f => f == typeof (T))))
                    .ToList();
        }
    }
}