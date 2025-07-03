using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Commands
{
    public class SeguradoCreateCommandHandler : IRequestHandler<SeguradoCreateCommand, Result<int>>
    {
        protected readonly IBaseRepository<Segurado> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        
        public SeguradoCreateCommandHandler(IBaseRepository<Segurado> baseRepository, IUnitOfWork unitOfWork)
        {
            _repository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(SeguradoCreateCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            Segurado entity = new Segurado
            {
                Nome = request.SeguradoCreateDto.Nome,
                Cpf = request.SeguradoCreateDto.Cpf,
                Idade = request.SeguradoCreateDto.Idade
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
