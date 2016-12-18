using System;
using MyCQRS.Domain.Entities;

namespace MyCQRS.Commands
{
    public class PostEditCommand : Command
    {
        public Post PostDetail { get; set; }

        public PostEditCommand(Guid id, int version, Post post) : base(id, version)
        {
            PostDetail = post;
        }
    }
}