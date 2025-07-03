using ExtracttaTest.Domain.Base;

namespace ExtracttaTest.Domain
{
    public sealed class Veiculo : BaseEntity
    {
        public double Valor {  get; set; }
        public string MarcaModelo { get; set; }
    }
}
