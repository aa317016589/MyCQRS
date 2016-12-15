using System;
using System.Collections.Generic;
using MyCQRS.ApplicationHelper;

namespace MyCQRS.Domain
{
    public abstract class AggregateRoot : IEventProvider
    {
        private readonly List<Event> _changes;

        public Guid Id { get; internal set; }
        public int Version { get; set; }
        public int EventVersion { get; protected set; }



        protected AggregateRoot()
        {
            _changes = new List<Event>();
        }


        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            dynamic d = this;

            d.handle(Converter.ChangeTo(@event, @event.GetType()));

            if (isNew)
            {
                _changes.Add(@event);
            }
        }



        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            throw new NotImplementedException();
        }

    }
}