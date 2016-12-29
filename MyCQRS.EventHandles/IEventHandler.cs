using System.Threading.Tasks;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public interface IEventHandler<TEvent> where TEvent :  Event
    {
        Task HandleAsync(TEvent handle);
    }
}