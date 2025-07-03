using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Queries
{
    public class VeiculoGetQuery : IRequest<Result<VeiculoDto>>
    {
        public int Id { get; set; }
        public VeiculoGetQuery(int id)
        {
            Id = id;
        }
    }
}
