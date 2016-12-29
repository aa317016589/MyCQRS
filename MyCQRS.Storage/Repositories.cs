using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MyCQRS.Domain;

namespace MyCQRS.Storage
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        protected IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=MyCQRS;User Id=sa;Password=sxf2013;multipleactiveresultsets=True;");
        }

        public async Task InsertAsync(T item)
        {
            using (var conn = GetConnection())
            {
                await conn.InsertAsync(item);
            }
        }

        public async Task DeleteAsync(Object condition)
        {
            using (var conn = GetConnection())
            {
                await conn.DeleteAsync<T>(condition);
            }
        }


        public async Task UpdateAsync(object data, object condition)
        {
            using (var conn = GetConnection())
            {
                await conn.UpdateAsync<T>(data, condition);
            }
        }
    }
}