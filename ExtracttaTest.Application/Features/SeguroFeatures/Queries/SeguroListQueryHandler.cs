using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroListQueryHandler : IRequestHandler<SeguroListQuery, Result<IEnumerable<SeguroDto>>>
    {
        protected readonly IBaseRepository<Seguro> _repository;

        public SeguroListQueryHandler(IBaseRepository<Seguro> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<Result<IEnumerable<SeguroDto>>> Handle(SeguroListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAllAsync(x => 1==1, [i => i.Veiculo, i => i.Segurado]);

            if (entity.Count == 0)
            {
                return Result<IEnumerable<SeguroDto>>.Fail("Nao existe segurados cadastrados");
            }

            IEnumerable<SeguroDto> dto = entity.Select(x => new SeguroDto
            {
                Id = x.Id,
                VeiculoId = x.Veiculo.Id,
                ValorSeguro = x.ValorSeguro,
                Veiculo = new VeiculoDto
                {   
                    Id = x.Veiculo.Id,
                    Valor = x.Veiculo.Valor,
                    MarcaModelo = x.Veiculo.MarcaModelo,
                },
                SeguradoId = x.Segurado.Id,
                Segurado = new SeguradoDto
                {
                    Id = x.Segurado.Id,
                    Nome = x.Segurado.Nome,
                    Cpf = x.Segurado.Cpf,
                    Idade = x.Segurado.Idade,
                }
            });

            return Result<IEnumerable<SeguroDto>>.Success(dto);
        }
    }
}
