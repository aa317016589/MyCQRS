using System;
using System.Collections.Generic;
using MyCQRS.Domain;

namespace MyCQRS.Storage
{
    public class Repositories<T> : IRepositories<T>
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}