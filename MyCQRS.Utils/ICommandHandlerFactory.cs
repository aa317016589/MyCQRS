using MyCQRS.CommandHandlers;
using MyCQRS.Commands;
 
namespace MyCQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}