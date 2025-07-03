using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;
using MediatR;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Commands
{
    public class VeiculoCreateCommand : IRequest<Result<int>>
    {
        public VeiculoCreateDto VeiculoCreateDto { get; set; } = new VeiculoCreateDto();

        public VeiculoCreateCommand(VeiculoCreateDto veiculoCreateDto)
        {
            this.VeiculoCreateDto = veiculoCreateDto;
        }
    }
}
