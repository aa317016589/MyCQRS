using System.Threading.Tasks;
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

        public async Task HandleAsync(PostEditEvent handle)
        {
            //保存到数据库
        }
    }
}