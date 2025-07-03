using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Interfaces.Repositories.Base;
using ExtracttaTest.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Commands
{
    public class VeiculoCreateCommandHandler : IRequestHandler<VeiculoCreateCommand, Result<int>>
    {
        protected readonly IBaseRepository<Veiculo> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public VeiculoCreateCommandHandler(IBaseRepository<Veiculo> baseRepository, IUnitOfWork unitOfWork)
        {
            _repository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(VeiculoCreateCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            Veiculo entity = new Veiculo
            {
                Valor = request.VeiculoCreateDto.Valor,
                MarcaModelo = request.VeiculoCreateDto.MarcaModelo
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
