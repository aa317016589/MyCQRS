using System;
using System.Collections.Generic;

namespace MyCQRS.Domain
{
    public interface IRepositories<T> where T : class
    { 
        void Add(T item);
        void Delete(Guid id);
        void Update(T item);
    }
}