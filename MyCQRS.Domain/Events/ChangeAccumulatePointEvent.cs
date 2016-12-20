using System;

namespace MyCQRS.Domain.Events
{
    public class ChangeAccumulatePointEvent : Event
    {
        public Int32 ChangeAccumulatePoint { get; set; }

        public ChangeAccumulatePointEvent(Guid aggregateId, Int32 changeAccumulatePoint)
        {
            AggregateId = aggregateId;
            Id = aggregateId;
            ChangeAccumulatePoint = changeAccumulatePoint;
        }
    }
}