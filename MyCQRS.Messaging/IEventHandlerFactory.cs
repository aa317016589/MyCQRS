using System.Collections.Generic;
using MyCQRS.Domain.Events;
using MyCQRS.EventHandles;

namespace MyCQRS.Messaging
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}
