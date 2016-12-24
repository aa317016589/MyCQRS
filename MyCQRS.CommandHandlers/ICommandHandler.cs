using System.Threading.Tasks;
using MyCQRS.Commands;

namespace MyCQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        Task ExecuteAsYnc(TCommand command);
    }
}