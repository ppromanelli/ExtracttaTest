namespace ExtracttaTest.Application.Commons
{
    public static class Utils
    {
        private static readonly double MARGEM_SEGURANÇA = 0.03;
        private static readonly double LUCRO = 0.05;

        public static double CalculaValorSeguro(this double valorVeiculo)
        {
            var TaxadeRisco = valorVeiculo * 5 / (2 * valorVeiculo);
            var PremiodeRisco = (TaxadeRisco/100) * valorVeiculo;
            var PremioPuro = PremiodeRisco * (1 + MARGEM_SEGURANÇA);
            var PremioComercial = (1+LUCRO) * PremioPuro;

            return Math.Round(PremioComercial,2);
        }
    }
}
