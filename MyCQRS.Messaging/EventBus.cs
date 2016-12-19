﻿using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Utils;

namespace MyCQRS.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly IEventHandlerFactory _eventHandlerFactory;
 
        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }

        public void Publish<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            foreach (var eventHandler in handlers)
            {
                eventHandler.Handle(@event);

                //搜寻该事件的后续操作，即不属于该聚合根的操作，由 IProcessBus 重新产生 command 发送
                //   _processBus.HandleAsync(@event);
            }
        }
    }
}