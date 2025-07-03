using ExtracttaTest.Application.Commons;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoCalculaSeguroQueryHandler : IRequestHandler<VeiculoCalculaSeguroQuery, Result<double>>
    {
        public async Task<Result<double>> Handle(VeiculoCalculaSeguroQuery request, CancellationToken cancellationToken)
        {
            double result = request.Valor.CalculaValorSeguro();

            return Result<double>.Success(result);
        }
    }
}
