using ClincSystem.DAL.DB;
using ClincSystem.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClincSystem.DAL.Repository.Implementation
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            } catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            } catch
            {
                return [];
            }
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>>? predicate, int? skip, int? take, params Expression<Func<T, object>>[]? includes)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (predicate != null)
                    query = query.Where(predicate);
                if (includes != null)
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }
                if (skip.HasValue)
                    query = query.Skip(skip.Value);
                if (take.HasValue)
                    query = query.Take(take.Value);
                return await query.ToListAsync();
            } catch 
            {
                return []; 
            }
        }
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[]? includes)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                if (includes != null)
                {
                    foreach (var include in includes)
                        query = query.Include(include);
                }

                return await query.FirstOrDefaultAsync(predicate);
            }
            catch
            {
                return default;
            }
            
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch
            {
                return;
            }
        }
        public Task UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return Task.CompletedTask;
            } catch
            {
                return default;
            }
        }
        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                    return false;

                _context.Set<T>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public Task DeleteEntityAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return Task.CompletedTask;
            }
            catch
            {
                return default;
            }
        }
        public Task<bool> DeleteAllAsync(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null || !entities.Any())
                    return Task.FromResult(false);

                _context.Set<T>().RemoveRange(entities);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
            
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            try
            {
                return predicate != null
                ? await _context.Set<T>().CountAsync(predicate)
                : await _context.Set<T>().CountAsync();
            }
            catch
            {
                return 0;
            }
        }
    }
}
