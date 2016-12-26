using MyCQRS.ApplicationHelper;
using MyCQRS.Domain.Entities;
using MyCQRS.Web.Models;

namespace MyCQRS.Web
{
    public class MapperConfig : IMapperConfig
    {
        private MapperConfig() { }

        public static MapperConfig Create()
        {
            return new MapperConfig();
        }

        public void SetConfig(IMapper mapper)
        {
            mapper.Bind<PostViewModel, Post>();

        }
    }

    public interface IMapperConfig
    {
        void SetConfig(IMapper mapper);
    }
}