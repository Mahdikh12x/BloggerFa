using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository<in TKey, T> where T : class
    {
        void Create(T entity);
        void SaveChanges();
        T? Get(TKey entity);
        IEnumerable<T> GetList();
        bool Exists(Expression<Func<T, bool>> expression);

        //Async Methods
        Task<T>? GetByAsync(TKey id);
        Task<T>? FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task<IEnumerable<T>>? GetAll();
        Task<IEnumerable<T>>? GetWhere(Expression<Func<T, bool>> predicate);
        Task<bool>  ExistsAsync (Expression<Func<T, bool>> expression);

        Task SaveChangesAsync();

        //Task<int> CountAll();
        //Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
