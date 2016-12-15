using System;
using MyCQRS.Domain.Entities;

namespace MyCQRS.Domain
{
    public class PostAddEvent : Event
    {
        public Post PostDetail { get; set; }

        public PostAddEvent(Guid aggregateId, Post post)
        {
            AggregateId = aggregateId;
            PostDetail = post;
        }
    }
}