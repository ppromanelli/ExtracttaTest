using ExtracttaTest.Domain.Base;

namespace ExtracttaTest.Domain
{
    public sealed class Segurado : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf {  get; set; }
        public int Idade { get; set; }
    }
}
