using MyCQRS.Commands;

namespace MyCQRS.CommandHandlers
{
    public interface ICommandHandler<out TCommand> where TCommand : Command
    {
        void Execute(Command command);
    }
}