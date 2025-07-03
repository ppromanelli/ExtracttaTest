using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroMediaAritmeticaQueryHandler : IRequestHandler<SeguroMediaAritmeticaQuery, Result<IEnumerable<SeguroMediaAritmeticaDto>>>
    {
        protected readonly IBaseRepository<Seguro> _repository;

        public SeguroMediaAritmeticaQueryHandler(IBaseRepository<Seguro> baseRepository)
        {
            _repository = baseRepository;
        }
        public async Task<Result<IEnumerable<SeguroMediaAritmeticaDto>>> Handle(SeguroMediaAritmeticaQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAllAsync(x => 1 == 1, [i => i.Veiculo, i => i.Segurado]);

            if (entity.Count == 0)
            {
                return Result<IEnumerable<SeguroMediaAritmeticaDto>>.Fail("Nao existe seguros cadastrados");
            }

            if (request.Filter?.ToUpper() == "SEGURADO")
            {
                var mediaPorSegurado = entity
                    .GroupBy(x => x.SeguradoId)
                    .Select(g => new SeguroMediaAritmeticaDto
                    {
                        SeguradoId = g.Key,
                        Descricao = g.First().Segurado.Nome,
                        MediaValorSeguro = Math.Round(g.Average(x => x.ValorSeguro),2)
                    })
                    .ToList();

                return Result<IEnumerable<SeguroMediaAritmeticaDto>>.Success(mediaPorSegurado);
            }

            if (request.Filter?.ToUpper() == "VEICULO")
            {
                var mediaPorVeiculo = entity
                    .GroupBy(x => x.VeiculoId)
                    .Select(g => new SeguroMediaAritmeticaDto
                    {
                        VeiculoId = g.Key,
                        Descricao = g.First().Veiculo.MarcaModelo,
                        MediaValorSeguro = Math.Round(g.Average(x => x.ValorSeguro),2)
                    })
                    .ToList();

                return Result<IEnumerable<SeguroMediaAritmeticaDto>>.Success(mediaPorVeiculo);
            }

            var valorSeguroMediaAritmetica = Math.Round(entity.Select(x => x.ValorSeguro).Average(), 2);

            var dto = new SeguroMediaAritmeticaDto
            {
                Descricao = "Media Geral",
                MediaValorSeguro = valorSeguroMediaAritmetica
            };
            IEnumerable<SeguroMediaAritmeticaDto> mediaAritmeticaGeral = new[] { dto }; ;   

            return Result<IEnumerable<SeguroMediaAritmeticaDto>>.Success(mediaAritmeticaGeral);
        }
    }
}
