using System;
using MyCQRS.Domain;
using MyCQRS.Domain.Entities;
using MyCQRS.Domain.Events;

namespace MyCQRS.EventHandles
{
    public class ChangeAccumulatePointEventHandle : IEventHandler<ChangeAccumulatePointEvent>
    {
        private readonly IRepositories<Post> _reportDatabase;
        public ChangeAccumulatePointEventHandle(IRepositories<Post> reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
 

        public void Handle(ChangeAccumulatePointEvent handle)
        {
           //保存到数据库
        }
    }
}