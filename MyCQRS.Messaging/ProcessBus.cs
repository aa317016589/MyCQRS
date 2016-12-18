using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public class ProcessBus : IProcessBus
    {
        public void HandleAsync<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}