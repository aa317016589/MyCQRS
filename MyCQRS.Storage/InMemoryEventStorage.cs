using System;
using System.Collections.Generic;
using System.Linq;
using MyCQRS.ApplicationHelper;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

using MyCQRS.Exceptions;
using MyCQRS.Mementos;
using MyCQRS.Messaging;


namespace MyCQRS.Storage
{
    public class InMemoryEventStorage : IEventStorage
    {
        private readonly List<Event> _events;
        private readonly List<BaseMemento> _mementos; //快照
        private readonly IEventBus _eventBus;


        public InMemoryEventStorage(IEventBus eventBus)
        {
            _events = new List<Event>();
            _mementos = new List<BaseMemento>();
            _eventBus = eventBus;
        }

        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(s => s.AggregateId == aggregateId);

            // ReSharper disable once PossibleMultipleEnumeration
            if (!events.Any())
            {
                throw new AggregateNotFoundException(String.Format("Aggregate with Id: {0} was not found", aggregateId));
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return events;
        }

        public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
        {
            var memento = _mementos.Where(m => m.Id == aggregateId).Select(m => m).LastOrDefault();

            if (memento == null)
            {
                return null;
            }

            return (T)memento;
        }

        public void Save(AggregateRoot aggregate)
        {
            var uncommittedChanges = aggregate.GetUncommittedChanges();
            var version = aggregate.Version;
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var @event in uncommittedChanges)
            {
                version++;
                if (version > 2)
                {
                    if (version % 3 == 0)
                    {
                        // ReSharper disable once SuspiciousTypeConversion.Global
                        var originator = (IOriginator)aggregate;
                        var memento = originator.GetMemento();
                        memento.Version = version;
                        SaveMemento(memento);
                    }
                }
                @event.Version = version;
                _events.Add(@event);
            }
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var @event in uncommittedChanges)
            {
                var desEvent = Converter.ChangeTo(@event, @event.GetType());
                _eventBus.Publish(desEvent);
            }
        }

        public void SaveMemento(BaseMemento memento)
        {
            _mementos.Add(memento);
        }

    }
}