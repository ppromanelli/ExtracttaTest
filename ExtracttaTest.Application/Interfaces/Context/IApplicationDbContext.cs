using ExtracttaTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ExtracttaTest.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        public DbContext Context { get; }
        public DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DbSet<Segurado> Segurado { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
    }
}
