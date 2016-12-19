using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly IEventHandlerFactory _eventHandlerFactory;

        private readonly IProcessFactory _processFactory;

        public EventBus(IEventHandlerFactory eventHandlerFactory, IProcessFactory processFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
            _processFactory = processFactory;
        }

        public void Publish<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);

                //搜寻该事件的后续操作，即不属于该聚合根的操作，由 _processFactory找到对应的Process 重新产生 command 发送
                _processFactory.Process<T>()?.HandleAsync(@event);
            }
        }
    }
}