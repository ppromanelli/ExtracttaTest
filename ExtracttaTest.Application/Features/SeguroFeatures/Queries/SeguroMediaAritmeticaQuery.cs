using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Queries
{
    public class SeguroMediaAritmeticaQuery : IRequest<Result<IEnumerable<SeguroMediaAritmeticaDto>>>
    {
        public string? Filter {  get; set; }

        public SeguroMediaAritmeticaQuery(string? filter)
        {
            Filter = filter;
        }
    }
}
