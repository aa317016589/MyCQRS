using System;
using System.Threading.Tasks;
using MyCQRS.Commands;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Messaging;

namespace MyCQRS.ProcessManagers
{
    public class PostAddProcess : IProcess<PostAddEvent>
    {
        public async Task ProcessAsync(PostAddEvent @event, ICommandBus commandBus)
        {
            await commandBus.SendAsync(new UserChangeAccumulatePointCommand(@event.PostDetail.UserId, @event.Version, 1));
        }
    }
}