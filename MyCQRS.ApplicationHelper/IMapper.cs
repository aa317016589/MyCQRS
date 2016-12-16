namespace MyCQRS.ApplicationHelper
{
    public interface IMapper
    {
        TTarget Map<TTarget>(object source);

        void Bind<TSource, TTarget>();
    }
}