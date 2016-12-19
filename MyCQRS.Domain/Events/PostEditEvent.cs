using System;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

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