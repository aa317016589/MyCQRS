using System;

namespace MyCQRS.Domain.Events
{
    [Serializable]
    public class Event
    {
        public int Version;
        public Guid AggregateId { get; set; }
        public Guid Id { get; protected set; }
    }
}