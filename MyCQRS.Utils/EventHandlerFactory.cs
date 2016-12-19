using System;
using System.Collections.Generic;
using System.Linq;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.EventHandles;

namespace MyCQRS.Utils
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            var handles = GetHandlerType<T>();

            return handles.Select(h => ApplicationHelper.Duplicate.Instance.Resolve<IEventHandler<T>>(h)).ToList();
        }

        private static IEnumerable<Type> GetHandlerType<T>() where T : Event
        {
            return typeof(IEventHandler<>).Assembly.GetExportedTypes()
                .Where(
                    x =>
                        x.GetInterfaces()
                            .Any(s => s.IsGenericType && s.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
                .Where(x => x.GetInterfaces().Any(s => s.GetGenericArguments().Any(a => a == typeof(T)))).ToList();
        }
    }
}