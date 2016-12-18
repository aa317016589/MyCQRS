using System.Collections.Generic;
using MyCQRS.QueryServices.DTOs;

namespace MyCQRS.QueryServices
{
    public interface IPostQueryServices
    {
        IEnumerable<PostQueryEntity> GetPosts();
    }
}