using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MyCQRS.Domain.AggregateRoots
{
    public class UserAggregate : AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public int AccumulatePoint { get; set; }
    }
}