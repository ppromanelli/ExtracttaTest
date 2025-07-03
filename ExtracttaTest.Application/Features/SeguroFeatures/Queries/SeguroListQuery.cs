using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroListQuery : IRequest<Result<IEnumerable<SeguroDto>>>
    {
    }
}
