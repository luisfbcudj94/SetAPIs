using API.Domain.Interfaces;
using API.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(Guid id)
        {
            var data = await _context.Set<T>().FindAsync(id);
            if (data != null)
            {
                _context.Entry(data).State = EntityState.Detached;
            }
            
            return data;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
