using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IProcess<T>
        where T : Event
    {
        void HandleAsync(T @event, ICommandBus commandBus);
    }
}