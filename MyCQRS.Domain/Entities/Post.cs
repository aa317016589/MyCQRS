using System;
using Dapper.Contrib.Extensions;

namespace MyCQRS.Domain.Entities
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        // ReSharper disable once BuiltInTypeReferenceStyle
        public String Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        // ReSharper disable once BuiltInTypeReferenceStyle
        public String Content { get; set; }

        /// <summary>
        /// 回复数
        /// </summary>
        public Int32 ReplyCount { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public Int32 GreatCount { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public Int32 ReadCount { get; set; }

        /// <summary>
        /// 发帖人
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        public Post()
        {
            PostId = Guid.NewGuid();
            ReplyCount = 0;
            ReadCount = 0;
            GreatCount = 0;
        }
    }
}