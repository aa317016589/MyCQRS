using System;
using System.Collections.Generic;
using MyCQRS.Domain;
using MyCQRS.EventHandles;

namespace MyCQRS.Utils
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event
        {
            throw new NotImplementedException();
        }
    }
}