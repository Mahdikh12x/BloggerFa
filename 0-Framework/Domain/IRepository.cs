using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<in TKey, T> where T :class
    {
       void Create(T entity);
        void SaveChanges();
        T? Get(TKey entity);
        IEnumerable<T> GetList();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
