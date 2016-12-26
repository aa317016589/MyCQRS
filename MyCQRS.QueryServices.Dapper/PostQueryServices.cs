using System.Collections.Generic;
using System.Linq;
using MyCQRS.QueryServices.DTOs;
using Dapper;
using Dapper.Contrib.Linq2Dapper.Extensions;

namespace MyCQRS.QueryServices.Dapper
{
    public class PostQueryServices : BaseQueryService, IPostQueryServices
    {
        public IEnumerable<PostQueryEntity> GetPosts()
        {
            using (var conn = GetConnection())
            {
                return conn.Query<PostQueryEntity>().ToList();
            }
        }
    }
}