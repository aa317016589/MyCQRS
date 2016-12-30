using System;

namespace MyCQRS.Web.Models
{
    public class PostViewModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        // ReSharper disable once BuiltInTypeReferenceStyle
        public String Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        // ReSharper disable once BuiltInTypeReferenceStyle
        public String Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid UserId { get; set; }
    }
}