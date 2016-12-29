using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Contrib.Linq2Dapper
{
    public static class QueryableExtensions
    {
        public static async Task<IList<TData>> ToListAsync<TData>(this IQueryable<TData> source)
        {
            var queryProvider = source.Provider as QueryProvider<TData>;
            // ReSharper disable once PossibleNullReferenceException
            return (await queryProvider.ExecuteAsync(source.Expression, true)) as IList<TData>;
        }


        public static async Task<TData> SingleOrDefaultAsync<TData>(this IQueryable<TData> source)
        {
            var queryProvider = source.Provider as QueryProvider<TData>;
            // ReSharper disable once PossibleNullReferenceException
            return (TData)await queryProvider.ExecuteAsync(source.Expression, false);
        }
    }
}