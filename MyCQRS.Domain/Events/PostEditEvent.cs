using System;
using MyCQRS.Domain.Entities;

namespace MyCQRS.Domain.Events
{
    public class PostEditEvent : Event
    {
        public Post PostDetail { get; set; }

        public PostEditEvent(Guid aggregateId, Post post)
        {
            AggregateId = aggregateId;
            PostDetail = post;
        }
    }
}