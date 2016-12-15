using MyCQRS.Domain;

namespace MyCQRS.EventHandles
{
    public interface IEventHandler<TEvent> where TEvent :  Event
    {
        void Handle(TEvent handle);
    }
}