using System.Threading.Tasks;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.ProcessManagers
{
    public interface IProcess<T>
        where T : Event
    {
        Task ProcessAsync(T @event, ICommandBus commandBus);
    }
}