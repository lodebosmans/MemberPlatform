using MemberPlatformDAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MemberPlatformDAL.UoW
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private DataContext _context;
        private DbSet<T> table = null;

        public GenericRepository(DataContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, string includeProperties)
        {
            return await table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public async Task Insert(T obj)
        {
            table.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            //_context.Entry(obj).State = EntityState.Detached;
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> AllQuery()
        {
            return table.AsQueryable<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await table.AnyAsync(e => e.Id == id);
        }
    }
}
