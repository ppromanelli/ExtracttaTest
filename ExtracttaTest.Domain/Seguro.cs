using ExtracttaTest.Domain.Base;

namespace ExtracttaTest.Domain
{
    public class Seguro : BaseEntity
    {
        public int SeguradoId { get; set; }
        public int VeiculoId { get; set; }
        public double ValorSeguro { get; set; }

        public Segurado Segurado { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
