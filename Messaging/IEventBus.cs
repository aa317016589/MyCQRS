using MyCQRS.Domain;

namespace MyCQRS.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : Event;
    }
}