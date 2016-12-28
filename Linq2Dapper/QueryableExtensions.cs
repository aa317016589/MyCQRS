using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Contrib.Linq2Dapper
{
    public static class QueryableExtensions
    {
        public static async Task<IList<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
        {
            var queryProvider = source.Provider as QueryProvider<TSource>;
            // ReSharper disable once PossibleNullReferenceException
            return (await queryProvider.ExecuteAsync(source.Expression)) as IList<TSource>;
        }
    }
}