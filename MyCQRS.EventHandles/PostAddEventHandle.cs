using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Entities;

namespace MyCQRS.EventHandles
{
    public class PostAddEventHandle : IEventHandler<PostAddEvent>
    {
        private readonly IRepositories<Post> _reportDatabase;
        public PostAddEventHandle(IRepositories<Post> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }


        public void Handle(PostAddEvent handle)
        {
            //数据库操作 
        }
    }
}