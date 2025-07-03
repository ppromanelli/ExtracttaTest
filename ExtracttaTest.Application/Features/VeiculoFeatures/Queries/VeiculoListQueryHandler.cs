using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoListQueryHandler : IRequestHandler<VeiculoListQuery, Result<IEnumerable<VeiculoDto>>>
    {
        protected readonly IBaseRepository<Veiculo> _repository;

        public VeiculoListQueryHandler(IBaseRepository<Veiculo> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<Result<IEnumerable<VeiculoDto>>> Handle(VeiculoListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAllAsync();

            if (entity.Count == 0)
            {
                return Result<IEnumerable<VeiculoDto>>.Fail("Nao existe veiculos cadastrados");
            }

            IEnumerable<VeiculoDto> dto = entity.Select(x => new VeiculoDto
            {
                Id = x.Id,
                Valor = x.Valor,
                MarcaModelo = x.MarcaModelo,
            });

            return Result<IEnumerable<VeiculoDto>>.Success(dto);
        }
    }
}
