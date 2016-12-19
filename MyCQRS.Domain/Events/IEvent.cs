using System;

namespace MyCQRS.Domain.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}