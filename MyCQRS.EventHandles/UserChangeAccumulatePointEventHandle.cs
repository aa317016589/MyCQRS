using System.Threading.Tasks;
using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class UserChangeAccumulatePointEventHandle : IEventHandler<ChangeAccumulatePointEvent>
    {
        private readonly IRepositories<User> _reportDatabase;
        public UserChangeAccumulatePointEventHandle(IRepositories<User> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
 

        public async Task HandleAsync(ChangeAccumulatePointEvent handle)
        {
           //保存到数据库
        }
    }
}