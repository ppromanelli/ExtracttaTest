using ExtracttaTest.Application.Commons;

namespace ExtracttaTest.Application.Features.SeguradoFeatures.Dtos
{
    public record class SeguradoDto : BaseDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
    }
}
