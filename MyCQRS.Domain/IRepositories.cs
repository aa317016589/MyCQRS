using System;
using System.Threading.Tasks;

namespace MyCQRS.Domain
{
    public interface IRepositories<T> where T : class
    {
        Task InsertAsync(T item);
        Task DeleteAsync(Object condition);
        Task UpdateAsync(Object data, Object condition);
    }
}