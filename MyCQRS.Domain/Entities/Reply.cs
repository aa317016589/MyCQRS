using System;

namespace MyCQRS.Domain.Entities
{
    public class Reply
    {
        public string Id { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 回复的帖子
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// 回复者
        /// </summary>
        public Guid ReplyerId { get; set; }

        /// <summary>
        /// 被回复者
        /// </summary>
        public Guid? ReplyedId { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}