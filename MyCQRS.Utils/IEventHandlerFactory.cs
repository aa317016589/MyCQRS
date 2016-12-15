using System;
using System.Collections.Generic;
using MyCQRS.Domain;
using MyCQRS.EventHandles;

namespace MyCQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}
