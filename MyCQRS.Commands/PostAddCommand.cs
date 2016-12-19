using System;
using MyCQRS.Domain.Entities;

namespace MyCQRS.Commands
{
    public class PostAddCommand : Command
    {
        public Post PostDetail { get; set; }

        public PostAddCommand(Guid id, Int32 version, Post post)
            : base(id, version)
        {
            PostDetail = post;
        }
    }
}