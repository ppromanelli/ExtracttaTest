using ExtracttaTest.Application.Interfaces.Context;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Infrastructure.Contexts;
using ExtracttaTest.Infrastructure.Migrations.Initializer;
using ExtracttaTest.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExtracttaTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static async void ApplyMigrations(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider;
                try
                {
                    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    applicationDbContext.Database.Migrate();

                    await DatabaseInitializer.SeedSegurado(applicationDbContext);
                    await DatabaseInitializer.SeedVeiculo(applicationDbContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
                
        }
    }
}
