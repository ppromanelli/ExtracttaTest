using ExtracttaTest.Application.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using ExtracttaTest.Infrastructure.Contexts;
using ExtracttaTest.Application.Interfaces.Context;

namespace ExtracttaTest.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;
        public DbContext DbContext => _dbContext.Context;

        public UnitOfWork(IApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await DbContext.Database.BeginTransactionAsync();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> Commit(CancellationToken cancellationToken = default)
        {
            try
            {
                if (_transaction == null)
                    _transaction = await DbContext.Database.BeginTransactionAsync();

                await DbContext.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;

                return 1;
            }
            catch
            {
                await Rollback();
                throw;
            }
        }

        public async Task Rollback()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            DbContext?.Dispose();
        }
    }
}
