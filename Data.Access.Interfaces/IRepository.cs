using System.Linq.Expressions;

namespace Data.Access.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> GetPaginatedAsync(
            int page,
            int pageSize,
            Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, object>>? include = null,
            Expression<Func<T, object>>? order = null
        );
        T? GetById(int id);
        Task<T>? GetByIdAsync(int id);
        T? GetSingle(Expression<Func<T, bool>> predicate);
        Task<T>? GetSingleAsync(Expression<Func<T, bool>> predicate);
        ICollection<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> FindAndOrderByAsync(
            Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, object>>? include = null,
            Expression<Func<T, object>>? order = null,
            bool enableTracking = true);
        Task<ICollection<T>> FindAndOrderByDescendingAsync(
            Expression<Func<T, bool>>? predicate = null,
            Expression<Func<T, object>>? include = null,
            Expression<Func<T, object>>? order = null,
            bool enableTracking = true);
        Task<T>? FindFirstByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        int Count();
        Task<int> CountAsync(
            Expression<Func<T, bool>>? predicate = null
        );
        void Add(T entity);
        void AddRange(ICollection<T> entities);
        void Remove(T entity);
        void RemoveRange(ICollection<T> entities);
    }
}
