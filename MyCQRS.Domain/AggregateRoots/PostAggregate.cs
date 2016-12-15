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
    public class PostAggregate : AggregateRoot,
        IHandle<PostAddEvent>
    {
        public Post PostDetail { get; set; }

        /// <summary>
        /// 回复集合
        /// </summary>
        public IList<Reply> Replies { get; set; }


        public PostAggregate(Guid id, Post post)
        {
            ApplyChange(new PostAddEvent(id, post));
        }

        public PostAggregate()
        {
            
        }


        public void Handle(PostAddEvent e)
        {
            PostDetail = e.PostDetail;
        }
    }
}