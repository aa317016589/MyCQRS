using System;

namespace MyCQRS.Domain
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}