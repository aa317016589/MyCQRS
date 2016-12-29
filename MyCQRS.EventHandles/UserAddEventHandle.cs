using System.Threading.Tasks;
using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class UserAddEventHandle : IEventHandler<UserAddEvent>
    {
        private readonly IRepositories<User> _reportDatabase;
        public UserAddEventHandle(IRepositories<User> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public async Task HandleAsync(UserAddEvent handle)
        {
            await _reportDatabase.InsertAsync(new User()
            {
                UserName = handle.UserName
            });
        }
    }
}