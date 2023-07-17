using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using net7_demo_api.Entities;
using net7_demo_api.Persistences;
using System;

namespace net7_demo_api.Repositories
{
    public class Repository : IBaseRepository
    {
        private readonly IMainDbContext _dbContext;
        private readonly TimeZoneInfo _est;
        private readonly DateTime utcNow;
        private readonly DateTime now;
        public readonly DateTime utcToLocal;
        public readonly DateTime localToUtc;
        public Repository(IMainDbContext dbContext)
        {
            _dbContext = dbContext;
            _est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            utcNow = DateTime.UtcNow;
            now = DateTime.Now;

            if (utcNow.Kind == DateTimeKind.Utc)
            {
                var oldKind = utcNow.Kind;
                utcToLocal = utcNow.ToLocalTime();
                var newKind = utcToLocal.Kind;

                Console.WriteLine($"Converted {utcNow} from {oldKind} to {newKind}: {utcToLocal}");
            }
            if (now.Kind == DateTimeKind.Local)
            {
                var oldKind = now.Kind;
                localToUtc = now.ToUniversalTime();
                var newKind = localToUtc.Kind;
                Console.WriteLine($"Converted {now} from {oldKind} to {newKind}: {localToUtc}");
            }
        }

        public async Task<T?> GetById<T>(int id) where T : IBaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IBaseEntity
        {
            var query = _dbContext.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
            where T : class
        {
            var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
            return orderBy != null
                ? orderBy(query).ToListAsync(cancellationToken)
                : query.ToListAsync(cancellationToken);
        }

        public Task<List<T>> FindAllAsync<T>(CancellationToken cancellationToken) where T : IBaseEntity
        {
            return _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression, string includeProperties) where T : IBaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();

            query = includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.SingleOrDefaultAsync(expression);
        }

        public T Add<T>(T entity) where T : IBaseEntity
        {
            entity.CreatedAt = localToUtc;
            entity.UpdatedAt = localToUtc;
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Update<T>(T entity) where T : IBaseEntity
        {
            entity.UpdatedAt = localToUtc;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : IBaseEntity
        {
            foreach (var item in entities)
            {
                item.UpdatedAt = localToUtc;
            }
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete<T>(T entity) where T : IBaseEntityWithDelete
        {
            entity.DeletedAt = DateTime.UtcNow;
            _dbContext.Set<T>().Remove(entity);
        }

        public Task<T?> GetByCode<T>(string code) where T : IBaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
