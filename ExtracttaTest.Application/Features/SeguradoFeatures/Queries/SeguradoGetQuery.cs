using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Queries
{
    public class SeguradoGetQuery : IRequest<Result<SeguradoDto>>
    {
        public int Id { get; set; }
        public SeguradoGetQuery(int id)
        {
            Id = id;
        }
    }
}
