using System.Linq.Expressions;
using net7_demo_api.Entities;

namespace net7_demo_api.Repositories
{
    public interface IBaseRepository
    {
        Task<T?> GetById<T>(int id) where T : IBaseEntity;
        Task<T?> GetByCode<T>(string code) where T : IBaseEntity;
        IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IBaseEntity;
        Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> FindAllAsync<T>(CancellationToken cancellationToken) where T : IBaseEntity;
        Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression, string includeProperties) where T : IBaseEntity;
        T Add<T>(T entity) where T : IBaseEntity;
        void Update<T>(T entity) where T : IBaseEntity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : IBaseEntity;
        void Delete<T>(T entity) where T : IBaseEntitySoftDelete;
    }
}
