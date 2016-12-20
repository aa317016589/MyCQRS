using System;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.ProcessManagers
{
    public class ProcessBus : IProcessBus
    {
        private readonly IProcessFactory _processFactory;

        private readonly ICommandBus _commandBus;

        public ProcessBus(IProcessFactory processFactory, ICommandBus commandBus)
        {
            _processFactory = processFactory;

            _commandBus = commandBus;
        }


        public void Handle<T>(T @event) where T : Event
        {
            _processFactory.Process<T>()?.HandleAsync(@event, _commandBus);
        }
    }
}