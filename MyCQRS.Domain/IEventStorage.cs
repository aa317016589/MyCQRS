using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCQRS.Domain.Events;
using MyCQRS.Mementos;

namespace MyCQRS.Domain
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);
        Task SaveAsync(AggregateRoot aggregate);
        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;
        void SaveMemento(BaseMemento memento);
    }
}