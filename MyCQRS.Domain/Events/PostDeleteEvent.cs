using System;

namespace MyCQRS.Domain.Events
{
    public class PostDeleteEvent : Event
    {
        public Guid PostId { get; private set; }

        public PostDeleteEvent(Guid postId)
        {
            PostId = postId;
        }
    }
}