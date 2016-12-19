using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public class ProcessBus : IProcessBus
    {
        private ICommandBus _commandBus { get; set; }

        public ProcessBus(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public void HandleAsync<T>(T @event) where T : Event
        {
            return _commandBus.Send(new AcceptNewReplyCommand(evnt.PostId, evnt.AggregateRootId));
        }
    }
}