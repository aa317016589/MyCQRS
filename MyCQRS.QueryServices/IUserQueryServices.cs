using System.Collections.Generic;
using System.Threading.Tasks;
using MyCQRS.QueryServices.DTOs;

namespace MyCQRS.QueryServices
{
    public interface IUserQueryServices
    {
        Task<IEnumerable<UserQueryEntity>> GetUser();
    }
}