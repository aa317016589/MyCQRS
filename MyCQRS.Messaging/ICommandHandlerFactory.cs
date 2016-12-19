using MyCQRS.CommandHandlers;
using MyCQRS.Commands;
 
namespace MyCQRS.Messaging
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}