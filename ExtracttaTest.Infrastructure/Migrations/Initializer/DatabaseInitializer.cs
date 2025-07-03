using ExtracttaTest.Domain;
using ExtracttaTest.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ExtracttaTest.Infrastructure.Migrations.Initializer
{
    public static class DatabaseInitializer
    {
        public static async Task SeedSegurado(ApplicationDbContext context)
        {
            var segurado1 = new Segurado
            {
                Nome = "Pedro Paulo",
                Cpf = "07604714609",
                Idade = 38
            };

            if (!context.Segurado.Any(x => x.Id == 1))
            {
                await context.Segurado.AddAsync(segurado1);
                await context.SaveChangesAsync();
            }

            var segurado2 = new Segurado
            {
                Nome = "Romanelli",
                Cpf = "17604714609",
                Idade = 18
            };

            if (!context.Segurado.Any(x => x.Id == 2))
            {
                await context.Segurado.AddAsync(segurado2);
                await context.SaveChangesAsync();
            }

            var segurado3 = new Segurado
            {
                Nome = "Pedro Teles",
                Cpf = "17604714909",
                Idade = 23
            };

            if (!context.Segurado.Any(x => x.Id == 3))
            {
                await context.Segurado.AddAsync(segurado3);
                await context.SaveChangesAsync();
            }

            var segurado4 = new Segurado
            {
                Nome = "Pedro Romanelli",
                Cpf = "13454714909",
                Idade = 29
            };

            if (!context.Segurado.Any(x => x.Id == 4))
            {
                await context.Segurado.AddAsync(segurado4);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedVeiculo(ApplicationDbContext context)
        {
            var veiculo1 = new Veiculo
            {
                Valor = 10000,
                MarcaModelo = "Corolla 1995"
            };

            if (!context.Veiculo.Any(x => x.Id == 1))
            {
                await context.Veiculo.AddAsync(veiculo1);
                await context.SaveChangesAsync();
            }

            var veiculo2 = new Veiculo
            {
                Valor = 20000,
                MarcaModelo = "Corolla 2001"
            };

            if (!context.Veiculo.Any(x => x.Id == 2))
            {
                await context.Veiculo.AddAsync(veiculo2);
                await context.SaveChangesAsync();
            }

            var veiculo3 = new Veiculo
            {
                Valor = 45000,
                MarcaModelo = "Corolla 2010"
            };

            if (!context.Veiculo.Any(x => x.Id == 3))
            {
                await context.Veiculo.AddAsync(veiculo3);
                await context.SaveChangesAsync();
            }

            var veiculo4 = new Veiculo
            {
                Valor = 130000,
                MarcaModelo = "Corolla 2022"
            };

            if (!context.Veiculo.Any(x => x.Id == 4))
            {
                await context.Veiculo.AddAsync(veiculo4);
                await context.SaveChangesAsync();
            }
        }


    }
}
