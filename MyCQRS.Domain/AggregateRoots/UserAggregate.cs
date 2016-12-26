using System;
using MyCQRS.Domain.Events;


namespace MyCQRS.Domain.AggregateRoots
{
    public class UserAggregate : AggregateRoot,
        IHandle<UserAddEvent>,
        IHandle<ChangeAccumulatePointEvent>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public Int32 AccumulatePoint { get; set; }

        public UserAggregate(Guid id, String userName)
        {
            ApplyChange(new UserAddEvent(id, userName));
        }

        public UserAggregate() { }


        public void Handle(ChangeAccumulatePointEvent e)
        {
            AccumulatePoint = AccumulatePoint + e.ChangeAccumulatePoint;
        }


        public void ChangeAccumulatePoint(Int32 accumulatePoint)
        {
            ApplyChange(new ChangeAccumulatePointEvent(Id, accumulatePoint));
        }

        public void Handle(UserAddEvent e)
        {
            Id = e.Id;
            UserName = e.UserName;
            AccumulatePoint = 0;
        }
    }
}