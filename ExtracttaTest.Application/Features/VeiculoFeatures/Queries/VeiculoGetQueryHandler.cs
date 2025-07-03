using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoGetQueryHandler : IRequestHandler<VeiculoGetQuery, Result<VeiculoDto>>
    {
        protected readonly IBaseRepository<Veiculo> _repository;

        public VeiculoGetQueryHandler(IBaseRepository<Veiculo> baseRepository)
        {
            _repository = baseRepository;
        }
        public async Task<Result<VeiculoDto>> Handle(VeiculoGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                return Result<VeiculoDto>.Fail("Entidade nao encontrada");
            }

            VeiculoDto dto = new VeiculoDto
            {
               Valor = entity.Valor,
               MarcaModelo = entity.MarcaModelo,
            };

            return Result<VeiculoDto>.Success(dto);
        }
    }
}
