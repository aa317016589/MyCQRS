using System;
using System.Collections.Generic;

namespace MyCQRS.Domain
{
    public interface IRepositories<T>
    {
        T GetById(Guid id);
        void Add(T item);
        void Delete(Guid id);
        List<T> GetItems();
    }
}