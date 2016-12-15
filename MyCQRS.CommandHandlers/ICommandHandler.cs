using MyCQRS.Commands;

namespace MyCQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}