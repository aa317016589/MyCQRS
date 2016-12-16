using MyCQRS.Commands;

namespace MyCQRS.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}