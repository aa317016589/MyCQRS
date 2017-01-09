using System.Threading.Tasks;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly IEventHandlerFactory _eventHandlerFactory;

        private readonly IProcessBus _processBus;

        public EventBus(IEventHandlerFactory eventHandlerFactory, IProcessBus processBus)
        {
            _eventHandlerFactory = eventHandlerFactory;
            _processBus = processBus;
        }

        public async Task PublishAsync<T>(T @event) where T : Event
        {
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            foreach (var eventHandler in handlers)
            {
                await eventHandler.HandleAsync(@event);

                //搜寻该事件的后续操作，即不属于该聚合根的操作，由 _processFactory找到对应的Process 重新产生 command 发送

                await _processBus.HandleAsync(@event);
            }
        }
    }
}