using System;
using System.Threading.Tasks;

namespace MyCQRS.Domain.Events
{
    public interface IEventRepository<T> where T : AggregateRoot, new()
    {
        Task SaveAsync(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}