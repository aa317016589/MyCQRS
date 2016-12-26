using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class PostDeleteEventHandle : IEventHandler<PostDeleteEvent>
    {
        private readonly IRepositories<Post> _reportDatabase;
        public PostDeleteEventHandle(IRepositories<Post> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(PostDeleteEvent handle)
        {
            //保存到数据库
        }
    }
}