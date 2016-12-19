using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IProcessBus
    {
        void HandleAsync<T>(T @event) where T : Event;
    }
}