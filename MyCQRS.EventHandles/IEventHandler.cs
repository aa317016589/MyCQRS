using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public interface IEventHandler<TEvent> where TEvent :  Event
    {
        void Handle(TEvent handle);
    }
}