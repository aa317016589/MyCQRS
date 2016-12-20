using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.ProcessManagers
{
    public interface IProcess<T>
        where T : Event
    {
        void Process(T @event, ICommandBus commandBus);
    }
}