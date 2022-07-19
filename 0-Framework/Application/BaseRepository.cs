using System.Linq.Expressions;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Application
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : class
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
            return _context.Set<T>().AsNoTracking<T>().Any(expression);
        }

        public T? Get(TKey entity)
        {
            return _context.Set<T>().Find(entity);
        }

        public async Task<T>? GetByAsync(TKey id) => await _context.Set<T>().FindAsync(id)! ?? null!;



        public async Task<T>? FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().FirstOrDefaultAsync(predicate)! ?? null!;

        public async Task CreateAsync(T entity) => await _context.AddAsync<T>(entity);

        public async Task<IEnumerable<T>>? GetAll() => await _context.Set<T>().AsNoTracking<T>().ToListAsync();

        public async Task<IEnumerable<T>>? GetWhere(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).AsNoTracking<T>().ToListAsync();

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) 
            =>await _context.Set<T>().AsNoTracking<T>().AnyAsync(expression);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
