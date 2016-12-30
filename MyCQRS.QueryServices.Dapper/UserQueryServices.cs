using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MyCQRS.QueryServices.DTOs;
using Dapper.Contrib.Linq2Dapper.Extensions;
using Dapper.Contrib.Linq2Dapper;

namespace MyCQRS.QueryServices.Dapper
{
    public class UserQueryServices : BaseQueryService, IUserQueryServices
    {
        public async Task<IEnumerable<UserQueryEntity>> GetUser()
        {
            return await Connection.Query<UserQueryEntity>().ToListAsync();
        }
    }
}