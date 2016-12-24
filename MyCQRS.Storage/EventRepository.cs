using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCQRS.ApplicationHelper.Threading;
using MyCQRS.Domain;
using MyCQRS.Domain.Events;
using MyCQRS.Exceptions;
using MyCQRS.Mementos;

namespace MyCQRS.Storage
{
    public class EventRepository<T> : IEventRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStorage _storage;
        private static readonly object _lockStorage = new object();

        public EventRepository(IEventStorage storage)
        {
            _storage = storage;
        }


        public T GetById(Guid id)
        {
            IEnumerable<Event> events;
            var memento = _storage.GetMemento<BaseMemento>(id);
            if (memento != null)
            {
                events = _storage.GetEvents(id).Where(e => e.Version >= memento.Version);
            }
            else
            {
                events = _storage.GetEvents(id);
            }
            var obj = new T();
            if (memento != null)
                ((IOriginator)obj).SetMemento(memento);

            obj.LoadsFromHistory(events);
            return obj;
        }

        public async Task SaveAsync(AggregateRoot aggregate, Int32 expectedVersion)
        {
            if (!aggregate.GetUncommittedChanges().Any())
            {
                return;
            }

            //这里锁，通常来说乐观锁的话，如果两个人同时操作第二个进来的时候，版本不对，直接GG
            await SuperveneHelper.InvokeAsync(aggregate.Id, () =>
            {
                //这里判断当前版本是不是初始化版本（新增加的默认值），如果不是，从事件存储里还原出最后的一个版本，来比较版本;
                //正常情况是一致的，因为之前已经增加这个对象，如果拿出来不是一致，说明锁失败了。
                if (expectedVersion != -1)
                {
                    var item = GetById(aggregate.Id);
                    if (item.Version != expectedVersion)
                    {
                        throw new ConcurrencyException(String.Format("Aggregate {0} has been previously modified", item.Id));
                    }
                }

                return _storage.SaveAsync(aggregate);
            });
        }
    }
}