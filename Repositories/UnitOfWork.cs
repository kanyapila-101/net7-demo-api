using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net7_demo_api.Persistences;

namespace net7_demo_api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMainDbContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(IMainDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IBaseRepository Repository()
        {
            return new Repository(_databaseContext);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _databaseContext.Dispose();
            _disposed = true;
        }

        
    }
}