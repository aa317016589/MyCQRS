using MyCQRS.Domain;

namespace MyCQRS.Messaging
{
    public interface IProcessBus
    {
        void HandleAsync<T>(T @event) where T : Event;
    }
}