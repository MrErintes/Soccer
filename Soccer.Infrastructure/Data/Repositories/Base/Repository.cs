using Blogs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Soccer.Core.Repositories.Base;

namespace Soccer.Infrastructure.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SoccerContext _soccerContext;

        public Repository(SoccerContext soccerContext)
        {
            _soccerContext = soccerContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _soccerContext.Set<T>().AddAsync(entity);
            await _soccerContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _soccerContext.Set<T>().Remove(entity);
            await _soccerContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _soccerContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _soccerContext.Set<T>().FindAsync(id);
        }
    }
}
