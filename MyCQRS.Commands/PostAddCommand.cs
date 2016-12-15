using System;

namespace MyCQRS.Commands
{
    public class PostAddCommand : Command
    {
        public PostAddCommand(Guid id, Int32 version)
            : base(id, version)
        {

        }
    }
}