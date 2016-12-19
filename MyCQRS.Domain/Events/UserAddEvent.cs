using System;

namespace MyCQRS.Domain.Events
{
    public class UserAddEvent : Event
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName { get; set; }

        ///// <summary>
        ///// 积分
        ///// </summary>
        //public Int32 AccumulatePoint { get; private set; }


        public UserAddEvent(Guid aggregateId, String userName)
        {
            AggregateId = aggregateId;
            UserName = userName;
            //AccumulatePoint = 0;
        }
    }
}