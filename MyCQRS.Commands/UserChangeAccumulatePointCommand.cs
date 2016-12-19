using System;

namespace MyCQRS.Commands
{
    public class UserChangeAccumulatePointCommand : Command
    {
        public Int32 ChangeAccumulatePoint { get; set; }

        public UserChangeAccumulatePointCommand(Guid id, Int32 version, Int32 changeAccumulatePoint) : base(id, version)
        {
            ChangeAccumulatePoint = changeAccumulatePoint;
        }
    }
}