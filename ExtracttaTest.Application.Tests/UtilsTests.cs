using Xunit;
using FluentAssertions;
using ExtracttaTest.Application.Commons;

namespace ExtracttaTest.Application.Tests
{
    public class UtilsTests
    {
        [Theory]
        [InlineData(10000, 270.37)]
        [InlineData(20000, 540.75)]
        [InlineData(50000, 1351.87)]
        public void CalculaValorSeguro_DeveRetornarValorEsperado(double valorVeiculo, double valorEsperado)
        {
            var resultado = valorVeiculo.CalculaValorSeguro();

            resultado.Should().BeApproximately(valorEsperado, 0.01);
        }
    }
}
