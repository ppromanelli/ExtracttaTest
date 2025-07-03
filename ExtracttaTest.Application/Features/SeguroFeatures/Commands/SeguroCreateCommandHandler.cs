using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Commands
{
    public class SeguroCreateCommandHandler : IRequestHandler<SeguroCreateCommand, Result<int>>
    {
        protected readonly IBaseRepository<Seguro> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<Segurado> _seguradoRepository;
        protected readonly IBaseRepository<Veiculo> _veiculoRepository;

        public SeguroCreateCommandHandler(IBaseRepository<Seguro> baseRepository, IUnitOfWork unitOfWork, IBaseRepository<Segurado> seguradoRepository, IBaseRepository<Veiculo> veiculoRepository)
        {
            _repository = baseRepository;
            _unitOfWork = unitOfWork;
            _seguradoRepository = seguradoRepository;
            _veiculoRepository = veiculoRepository;
        }
        public async Task<Result<int>> Handle(SeguroCreateCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var veiculo = await _veiculoRepository.GetByIdAsync(request.Dto.VeiculoId);

            Seguro entity = new Seguro
            {
                VeiculoId = request.Dto.VeiculoId,
                SeguradoId = request.Dto.SeguradoId,
                ValorSeguro = veiculo!.Valor.CalculaValorSeguro()
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
