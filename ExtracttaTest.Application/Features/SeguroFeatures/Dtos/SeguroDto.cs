using ExtracttaTest.Application.Commons;
using ExtracttaTest.Application.Features.SeguradoFeatures.Dtos;
using ExtracttaTest.Application.Features.VeiculoFeatures.Dtos;

namespace ExtracttaTest.Application.Features.SeguroFeatures.Dtos
{
    public record class SeguroDto : BaseDto
    {
        public int? VeiculoId { get; set; }
        public int? SeguradoId { get; set; }
        public double? ValorSeguro { get; set; }

        public VeiculoDto? Veiculo { get; set; }
        public SeguradoDto? Segurado { get; set; }
    }
}
