using System.Threading.Tasks;
using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class PostAddEventHandle : IEventHandler<PostAddEvent>
    {
        private readonly IRepositories<Post> _reportDatabase;
        public PostAddEventHandle(IRepositories<Post> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }


        public async Task HandleAsync(PostAddEvent handle)
        {
            //数据库操作 
            await _reportDatabase.InsertAsync(handle.PostDetail);
        }
    }
}