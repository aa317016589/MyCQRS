using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Linq2Dapper;
using MyCQRS.Domain.Entities;
using MyCQRS.QueryServices.DTOs;

namespace MyCQRS.Web
{
    public class TableMapConfig
    {
        // TableMap.Config
        public static void Init()
        {
            TableMap.Config<PostQueryEntity>("Post").Key(s => s.PostId);

            TableMap.Config<UserQueryEntity>("User").Key(s => s.UserId);

            TableMap.Config<User>().Key(s => s.UserId);

            TableMap.Config<Post>().Key(s => s.PostId);
        }
    }
}