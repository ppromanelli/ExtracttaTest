using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Queries
{
    public class SeguradoListQuery : IRequest<Result<IEnumerable<SeguradoDto>>>
    {
    }
}
