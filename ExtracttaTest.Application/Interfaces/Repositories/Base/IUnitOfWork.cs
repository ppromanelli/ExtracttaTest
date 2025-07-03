using Microsoft.EntityFrameworkCore;

namespace ExtracttaTest.Application.Interfaces.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        Task BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> Commit(CancellationToken cancellationToken = default);
        Task Rollback();
    }
}
