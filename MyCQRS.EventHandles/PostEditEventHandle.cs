using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class PostEditEventHandle : IEventHandler<PostEditEvent>
    {
        private readonly IRepositories<Post> _reportDatabase;
        public PostEditEventHandle(IRepositories<Post> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(PostEditEvent handle)
        {
            //保存到数据库
        }
    }
}