using System.Threading.Tasks;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event) where T : Event;
    }
}