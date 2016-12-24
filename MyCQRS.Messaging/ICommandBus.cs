using System.Threading.Tasks;
using MyCQRS.Commands;

namespace MyCQRS.Messaging
{
    public interface ICommandBus
    {
        Task SendAsync<T>(T command) where T : Command;
    }
}