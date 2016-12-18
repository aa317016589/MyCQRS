using System.Data;
using System.Data.SqlClient;
 

namespace MyCQRS.QueryServices.Dapper
{
    public abstract class BaseQueryService
    {
        protected IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=MyCQRS;User Id=sa;Password=sxf2013;multipleactiveresultsets=True;");
        }
    }
}
