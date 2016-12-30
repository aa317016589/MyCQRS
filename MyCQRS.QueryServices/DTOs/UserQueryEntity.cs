using System;

namespace MyCQRS.QueryServices.DTOs
{
    public class UserQueryEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public Int32 AccumulatePoint { get; set; }
    }
}