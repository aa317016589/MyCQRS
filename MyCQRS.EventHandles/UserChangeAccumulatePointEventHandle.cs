using System;
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
 

        public void Handle(ChangeAccumulatePointEvent handle)
        {
           //保存到数据库
        }
    }
}