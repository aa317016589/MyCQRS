using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;
using MyCQRS.Domain.Mementos;
using MyCQRS.Mementos;


namespace MyCQRS.Domain.AggregateRoots
{
    /// <summary>
    /// 帖子
    /// </summary>
    public class PostAggregate : AggregateRoot,
        IHandle<PostAddEvent>,
        IHandle<PostEditEvent>,
        IHandle<PostDeleteEvent>,
        IOriginator
    {
        public Post PostDetail { get; set; }

        ///// <summary>
        ///// 回复集合
        ///// </summary>
        //public IList<Reply> Replies { get; set; }


        public PostAggregate(Guid id, Post post)
        {
            ApplyChange(new PostAddEvent(id, post));
        }

        public PostAggregate()
        {

        }


        public void Delete()
        {
            ApplyChange(new PostDeleteEvent(Id));
        }


        public void Handle(PostAddEvent e)
        {
            PostDetail = e.PostDetail;
        }

        public void Handle(PostEditEvent e)
        {
            PostDetail = e.PostDetail;
        }

        public void Handle(PostDeleteEvent e)
        {

        }

        public BaseMemento GetMemento()
        {
            return new PostMemento(Id, PostDetail.Title, PostDetail.Content, PostDetail.ReplyCount,
                PostDetail.GreatCount, PostDetail.ReadCount, PostDetail.UserId, PostDetail.CreateDateTime, Version);
        }

        public void SetMemento(BaseMemento memento)
        {
            var postMemento = memento as PostMemento;

            Id = memento.Id;
            // ReSharper disable once PossibleNullReferenceException
            PostDetail.Title = postMemento.Title;
            PostDetail.Content = postMemento.Content;
            PostDetail.ReplyCount = memento.Version;
            PostDetail.GreatCount = postMemento.GreatCount;
            PostDetail.ReadCount = postMemento.ReadCount;
            PostDetail.UserId = postMemento.Id;
            PostDetail.CreateDateTime = postMemento.CreateDateTime;
            Version = postMemento.Version;
        }
    }
}