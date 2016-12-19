using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCQRS.Domain.Events;


namespace MyCQRS.Domain.AggregateRoots
{
    public class UserAggregate : AggregateRoot,
        IHandle<ChangeAccumulatePointEvent>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int AccumulatePoint { get; set; }

        public void Handle(ChangeAccumulatePointEvent e)
        {
            AccumulatePoint = AccumulatePoint + e.ChangeAccumulatePoint;
        }
    }
}