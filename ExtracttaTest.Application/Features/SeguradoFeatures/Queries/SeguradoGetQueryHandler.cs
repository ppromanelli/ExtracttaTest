using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Queries
{
    public class SeguradoGetQueryHandler : IRequestHandler<SeguradoGetQuery, Result<SeguradoDto>>
    {
        protected readonly IBaseRepository<Segurado> _repository;
        public SeguradoGetQueryHandler(IBaseRepository<Segurado> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<Result<SeguradoDto>> Handle(SeguradoGetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindFirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
            {
                return Result<SeguradoDto>.Fail("Entidade nao encontrada");
            }

            SeguradoDto dto = new SeguradoDto
            {
                Id = request.Id,
                Nome = entity.Nome,
                Cpf = entity.Cpf,
                Idade = entity.Idade
            };

            return Result<SeguradoDto>.Success(dto);
        }
    }
}
