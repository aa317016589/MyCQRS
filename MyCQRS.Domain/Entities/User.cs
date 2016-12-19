using System;

namespace MyCQRS.Domain.Entities
{
    public class User
    {

        public Guid UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public Int32 AccumulatePoint { get; set; }
    }
}