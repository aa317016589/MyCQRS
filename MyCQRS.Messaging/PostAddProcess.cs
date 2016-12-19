using System;
using MyCQRS.CommandHandlers;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;

namespace MyCQRS.Messaging
{
    public class PostAddProcess : IProcessBus<PostAddEvent>
    {
        private ICommandBus CommandBus { get; set; }

        public PostAddProcess(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
  
        public void HandleAsync(PostAddEvent @event)
        {
            CommandBus.Send(new UserChangeAccumulatePointCommand(@event.Id, @event.Version, 1));
        }
    }
}