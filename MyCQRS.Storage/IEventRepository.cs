using System;
using MyCQRS.Domain;

namespace MyCQRS.Storage
{
    public interface IEventRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}