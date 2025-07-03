using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoCalculaSeguroQuery : IRequest<Result<double>>
    {
        public double Valor { get; set; }
        public VeiculoCalculaSeguroQuery(VeiculoCalculaSeguroDto veiculoCalculaSeguroDto)
        {
           Valor = veiculoCalculaSeguroDto.Valor;
        }
    }
}
