using System.Linq.Expressions;

namespace ClincSystem.DAL.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>>? predicate, int? skip, int? take, params Expression<Func<T, object>>[]? includes);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[]? includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
        Task DeleteEntityAsync(T Entity);
        Task<bool> DeleteAllAsync(IEnumerable<T> entities);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
