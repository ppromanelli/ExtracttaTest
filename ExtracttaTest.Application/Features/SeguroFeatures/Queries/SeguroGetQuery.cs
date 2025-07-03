using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroGetQuery : IRequest<Result<SeguroDto>>
    {
        public int Id { get; set; }
        public SeguroGetQuery(int id)
        {
            Id = id;
        }
    }
}
