using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using MyCQRS.Domain;
using Dapper.Contrib.Extensions;
using Dapper.Contrib.Linq2Dapper.Extensions;
using Dapper;

namespace MyCQRS.Storage
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        protected IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=MyCQRS;User Id=sa;Password=sxf2013;multipleactiveresultsets=True;");
        }

        public void Add(T item)
        {
            using (var conn = GetConnection())
            {
                conn.Insert(item);
            }
        }

        public void Delete(Guid id)
        {
            //using (var conn = GetConnection())
            //{
            //    conn.Delete(null);
            //}
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}