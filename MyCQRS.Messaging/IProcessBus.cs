using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IProcessBus<T> where T : Event
    {
        void HandleAsync(T @event);
    }
}