using System;
using MyCQRS.Domain;

namespace MyCQRS.Domain
{
    public interface IEventRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}