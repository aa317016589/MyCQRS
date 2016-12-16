using System;
using System.Collections.Generic;
using MyCQRS.Domain;
using MyCQRS.Domain.Mementos;

namespace MyCQRS.Storage
{
    public class InMemoryEventStorage : IEventStorage
    {
        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
        {
            throw new NotImplementedException();
        }

        public void Save(AggregateRoot aggregate)
        {
            throw new NotImplementedException();
        }

        public void SaveMemento(BaseMemento memento)
        {
            throw new NotImplementedException();
        }
    }
}