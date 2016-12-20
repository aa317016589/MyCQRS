using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IProcessBus
    {
        void Handle<T>(T @event) where T : Event;
    }
}