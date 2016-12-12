using System;
using MyCQRS.Domain;

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