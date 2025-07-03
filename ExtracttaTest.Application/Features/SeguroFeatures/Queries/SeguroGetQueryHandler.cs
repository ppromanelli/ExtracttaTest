using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroGetQueryHandler : IRequestHandler<SeguroGetQuery, Result<SeguroDto>>
    {
        protected readonly IBaseRepository<Seguro> _repository;

        public SeguroGetQueryHandler(IBaseRepository<Seguro> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<Result<SeguroDto>> Handle(SeguroGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindFirstOrDefaultAsync(x => x.Id == request.Id,[ i => i.Veiculo,i => i.Segurado]);

            if (entity == null)
            {
                return Result<SeguroDto>.Fail("Entidade nao encontrada");
            }

            SeguroDto dto = new SeguroDto
            {
                Id = request.Id,
                VeiculoId = entity.Veiculo.Id,
                ValorSeguro = entity.ValorSeguro,
                Veiculo = new VeiculoDto
                {
                    Id = entity.Veiculo.Id,
                    Valor = entity.Veiculo.Valor,
                    MarcaModelo = entity.Veiculo.MarcaModelo,
                },
                SeguradoId = entity.Segurado.Id,
                Segurado = new SeguradoDto
                {
                    Id = entity.Segurado.Id,
                    Nome = entity.Segurado.Nome,
                    Cpf = entity.Segurado.Cpf,
                    Idade = entity.Segurado.Idade,
                }
            };

            return Result<SeguroDto>.Success(dto);
        }
    }
}
