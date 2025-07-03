using ExtracttaTest.Application.Commons;

namespace ExtracttaTest.Application.Features.VeiculoFeatures.Dtos
{
    public record class VeiculoDto : BaseDto
    {
        public double Valor { get; set; }
        public string MarcaModelo { get; set; }
    }
}
