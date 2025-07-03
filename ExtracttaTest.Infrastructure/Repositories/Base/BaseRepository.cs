using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExtracttaTest.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = _unitOfWork.DbContext;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;

            _dbSet.Update(entity);
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entidade com ID {id} não encontrada.");

            await DeleteAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public virtual async Task<TEntity?> FindFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable().Where(predicate);
            query = ApplyIncludes(query, includes);
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsQueryable().Where(predicate);
            query = ApplyIncludes(query, includes);
            return await query.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(predicate);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking()
                .CountAsync(predicate);
        }
        private IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

    }
}
