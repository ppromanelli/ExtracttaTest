using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoListQuery : IRequest<Result<IEnumerable<VeiculoDto>>>
    {
    }
}
