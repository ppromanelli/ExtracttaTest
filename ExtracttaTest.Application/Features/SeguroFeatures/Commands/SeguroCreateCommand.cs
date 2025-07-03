using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguroFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Commands
{
    public class SeguroCreateCommand : IRequest<Result<int>>
    {
        public SeguroCreateDto Dto { get; set; } = new SeguroCreateDto();

        public SeguroCreateCommand(SeguroCreateDto seguroCreateDto)
        {
            this.Dto = seguroCreateDto;
        }
    }
}
