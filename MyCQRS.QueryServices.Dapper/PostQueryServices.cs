using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCQRS.QueryServices.DTOs;
using Dapper;
using Dapper.Contrib.Linq2Dapper.Extensions;
using Dapper.Contrib.Linq2Dapper;

namespace MyCQRS.QueryServices.Dapper
{
    public class PostQueryServices : BaseQueryService, IPostQueryServices
    {
        public async Task<IEnumerable<PostQueryEntity>> GetPosts()
        {
            return await GetConnection().Query<PostQueryEntity>().ToListAsync();
        }
    }
}