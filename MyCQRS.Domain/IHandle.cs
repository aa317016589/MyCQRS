namespace MyCQRS.Domain
{
    public interface IHandle<TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}