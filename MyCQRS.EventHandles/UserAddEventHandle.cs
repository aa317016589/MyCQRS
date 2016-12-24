using System;
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

        public void Handle(UserAddEvent handle)
        {
            _reportDatabase.Add(new User()
            {
                UserName = handle.UserName
            });
        }
    }
}