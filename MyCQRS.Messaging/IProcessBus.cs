using System.Threading.Tasks;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public interface IProcessBus
    {
        Task HandleAsync<T>(T @event) where T : Event;
    }
}