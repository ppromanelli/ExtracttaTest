using ExtracttaTest.Application.Interfaces.Context;
using ExtracttaTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExtracttaTest.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbContext Context => this;

        public DbSet<Segurado> Segurado { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Seguro> Seguro { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
