using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Linq2Dapper;
using MyCQRS.QueryServices.DTOs;

namespace MyCQRS.Web
{
    public class TableMapConfig
    {
        // TableMap.Config
        public static void Init()
        {
            TableMap.Config<PostQueryEntity>("Post").Key(s => s.PostId);
        }
    }
}