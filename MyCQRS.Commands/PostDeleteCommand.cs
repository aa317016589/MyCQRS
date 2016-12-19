using System;
using MyCQRS.Domain.Entities;

namespace MyCQRS.Commands
{
    public class PostDeleteCommand : Command
    {
        public PostDeleteCommand(Guid id, Int32 version)
            : base(id, version)
        {

        }
    }
}