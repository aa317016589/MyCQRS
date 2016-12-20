using System;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.ProcessManagers
{
    public class PostAddProcess : IProcess<PostAddEvent>
    {
        public void HandleAsync(PostAddEvent @event, ICommandBus commandBus)
        {
            commandBus.Send(new UserChangeAccumulatePointCommand(@event.PostDetail.UserId, @event.Version, 1));
        }
    }
}