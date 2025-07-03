using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Queries
{
    public class SeguradoListQueryHandler : IRequestHandler<SeguradoListQuery, Result<IEnumerable<SeguradoDto>>>
    {
        protected readonly IBaseRepository<Segurado> _repository;
        
        public SeguradoListQueryHandler(IBaseRepository<Segurado> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<Result<IEnumerable<SeguradoDto>>> Handle(SeguradoListQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAllAsync();

            if (entity.Count == 0)
            {
                return Result<IEnumerable<SeguradoDto>>.Fail("Nao existe segurados cadastrados");
            }

            IEnumerable<SeguradoDto> dto = entity.Select(x => new SeguradoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Cpf = x.Cpf,
                Idade = x.Idade
            });

            return Result<IEnumerable<SeguradoDto>>.Success(dto);
        }
    }
}
