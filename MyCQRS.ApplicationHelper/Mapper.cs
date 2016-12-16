using System;
using Nelibur.ObjectMapper;

namespace MyCQRS.ApplicationHelper
{
    public class Mapper : IMapper
    {
        public void Bind<TSource, TTarget>()
        {
            TinyMapper.Bind<TSource, TTarget>();
        }

        public TTarget Map<TTarget>(object source)
        {
            return TinyMapper.Map<TTarget>(source);
        }
    }
}