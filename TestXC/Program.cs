using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Dapper.Contrib.Linq2Dapper;
using Dapper.Contrib.Linq2Dapper.Extensions;
using MyCQRS.ApplicationHelper;
using MyCQRS.CommandHandlers;
using MyCQRS.Domain;
using MyCQRS.Domain.AggregateRoots;
using MyCQRS.Domain.Events;
using MyCQRS.EventHandles;
using MyCQRS.Messaging;
using MyCQRS.ProcessManagers;
using MyCQRS.Storage;
using MyCQRS.Utils;
using MyCQRS.Web.Auxiliary;

namespace TestXC
{
    class Program
    {
        static void Main(string[] args)
        {
            PostXC postXc = new PostXC();
            postXc.Id = Guid.NewGuid();

            string Name = "swallow";

            String result =  "{Name}:{Name}";

            Console.WriteLine(string.Format("Aggregate {{postXc.Id} has been previously modified") );



            Console.ReadKey();


            return;



            TableMap.Config<PostXC>("Post").Map(s => s.Id, "PostId").Key(s => s.Id).Ignore(s => s.Content);

            using (var conn = GetConnection())
            {
                var posts = conn.Query<PostXC>().ToList();
                Console.WriteLine(posts.Count);
                posts.ForEach(s =>
                {
                    Console.WriteLine(s.Id);
                });
            }

 
            using (var conn = GetConnection())
            {
                var posts = conn.Query<PostXC>().ToList();
                Console.WriteLine(posts.Count);
                posts.ForEach(s =>
                {
                    Console.WriteLine(s.Id);
                });
            }

            Console.ReadKey();
        }

        static IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=MyCQRS;User Id=sa;Password=sxf2013;multipleactiveresultsets=True;");
        }
    }


    public class PostXC
    {

        public Guid Id { get; set; }

        public String Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        // ReSharper disable once BuiltInTypeReferenceStyle
        public String Content { get; set; }

        /// <summary>
        /// 回复数
        /// </summary>
        public Int32 ReplyCount { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public Int32 GreatCount { get; set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public Int32 ReadCount { get; set; }

        /// <summary>
        /// 发帖人
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
