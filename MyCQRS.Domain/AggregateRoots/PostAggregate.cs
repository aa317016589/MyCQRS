using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCQRS.Domain.Entities;


namespace MyCQRS.Domain.AggregateRoots
{
    /// <summary>
    /// 帖子
    /// </summary>
    public class PostAggregate : AggregateRoot
    {
        public Post PostDetail { get; set; }

        /// <summary>
        /// 回复集合
        /// </summary>
        public IList<Reply> Replies { get; set; }
    }
}