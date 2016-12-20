using System;
using MyCQRS.Mementos;

namespace MyCQRS.Domain.Mementos
{
    public class PostMemento : BaseMemento
    {
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


        public PostMemento(Guid id, String title, String content, Int32 replyCount, Int32 greatCount, Int32 readCount, Guid userId, DateTime createDateTime, Int32 version)
        {
            Id = id;
            Title = title;
            Content = content;
            ReplyCount = replyCount;
            GreatCount = greatCount;
            ReadCount = readCount;
            UserId = userId;
            CreateDateTime = createDateTime;
            Version = version;
        }
    }
}