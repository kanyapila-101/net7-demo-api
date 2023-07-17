using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net7_demo_api.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository Repository();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}