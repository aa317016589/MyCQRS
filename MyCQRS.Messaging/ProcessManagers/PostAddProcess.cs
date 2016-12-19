using System;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.Messaging.ProcessManagers
{
    public class PostAddProcess : IProcess<PostAddEvent>
    {
        private ICommandBus CommandBus { get; set; }

        public PostAddProcess(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
  
        public void HandleAsync(PostAddEvent @event)
        {
            CommandBus.Send(new UserChangeAccumulatePointCommand(@event.PostDetail.UserId, @event.Version, 1));
        }
    }
}