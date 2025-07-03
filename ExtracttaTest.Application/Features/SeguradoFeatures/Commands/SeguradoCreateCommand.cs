using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Commands
{
    public class SeguradoCreateCommand : IRequest<Result<int>>
    {
        public SeguradoCreateDto SeguradoCreateDto { get; set; } = new SeguradoCreateDto();

        public SeguradoCreateCommand(SeguradoCreateDto seguradoCreateDto)
        {
            this.SeguradoCreateDto = seguradoCreateDto;
        }
    }
}
