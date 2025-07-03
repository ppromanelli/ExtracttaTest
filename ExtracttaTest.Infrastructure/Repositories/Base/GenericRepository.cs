using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain.Base;
using Microsoft.AspNetCore.Http;

namespace ExtracttaTest.Infrastructure.Repositories.Base
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity>, IBaseRepository<TEntity>
    where TEntity : BaseEntity
    {
        public GenericRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
