using MyCQRS.Domain;

namespace MyCQRS.EventHandles
{
    public interface IEventHandler<out TEvent> where TEvent :  Event
    {
        void Handle(Event handle);
    }
}