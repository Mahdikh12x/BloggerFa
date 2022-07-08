using System.Linq.Expressions;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Application
{
    public class BaseRepository<TKey,T>:IRepository<TKey,T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetList()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsQueryable().Any(expression);
        }

        public T? Get(TKey entity)
        {
            return _context.Set<T>().Find(entity);
        }

    } 
}
