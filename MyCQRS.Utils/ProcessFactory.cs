using System;
using System.Linq;
using MyCQRS.ApplicationHelper;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.Utils
{
    public class ProcessFactory : IProcessFactory
    {
        public IProcess<T> Process<T>() where T : Event
        {
            Type type = GetProcessTypes<T>();

            if (type == null)
            {
                return null;
            }

            return (IProcess<T>) Duplicate.Instance.Resolve(type);
        }

        private Type GetProcessTypes<T>() where T : Event
        {
            return typeof(IProcessFactory).Assembly.GetExportedTypes()
                .FirstOrDefault(
                    s =>
                        s.GetInterfaces()
                            .Any(
                                a =>
                                    a == typeof(IProcess<T>) &&
                                    a.GetGenericArguments().Any(g => g == typeof(T))));
        }
    }
}