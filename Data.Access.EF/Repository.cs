using Data.Access.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Access.EF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public int Count()
        {
            return _entities.Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> query = _entities;

            if (predicate != null) query = query.Where(predicate);

            return await query.CountAsync();
        }

        public async Task<ICollection<TEntity>> FindAndOrderByAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, object>>? include = null,
            Expression<Func<TEntity, object>>? order = null, bool enableTracking = true)
        {
            IQueryable<TEntity> query = _entities;

            if (!enableTracking) query = query.AsNoTracking();
            if (predicate != null) query = query.Where(predicate);
            if (include != null) query = query.Include(include);
            if (order != null) query = query.OrderBy(order);
            return await query.ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindAndOrderByDescendingAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, object>>? include = null,
            Expression<Func<TEntity, object>>? order = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> query = _entities;

            if (!enableTracking) query = query.AsNoTracking();
            if (predicate != null) query = query.Where(predicate);
            if (include != null) query = query.Include(include);
            if (order != null) query = query.OrderByDescending(order);
            return await query.ToListAsync();
        }

        public ICollection<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity>? FindFirstByAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public ICollection<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _entities;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public TEntity? GetById(int id)
        {
            TEntity? entity = _entities.Find(id);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given ID.");
            }

            return entity;
        }

        public async Task<TEntity>? GetById(Guid id)
        {
            TEntity? entity = await _entities.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given ID.");
            }

            return entity;
        }

        public async Task<TEntity>? GetByIdAsync(int id)
        {
            TEntity? entity = await _entities.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given ID.");
            }

            return entity;
        }

        public async Task<TEntity>? GetByIdAsync(Guid id)
        {
            TEntity? entity = await _entities.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given ID.");
            }

            return entity;
        }

        public async Task<ICollection<TEntity>> GetPaginatedAsync(int page, int pageSize)
        {
            return await _entities
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<ICollection<TEntity>> GetPaginatedAsync(int page, int pageSize, Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? include = null, Expression<Func<TEntity, object>>? order = null)
        {
            throw new NotImplementedException();
        }

        public TEntity? GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = _entities.FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given predicate.");
            }

            return entity;
        }

        public async Task<TEntity>? GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity? entity = await _entities.FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                throw new InvalidOperationException("No entity found matching the given predicate.");
            }

            return entity;
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

    }
}
