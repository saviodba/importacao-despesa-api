namespace Orcamento.Core.ValueObjects
{
    public class ParcelamentoVO
    {
        public int QuantidadeParcelas { get; private set; }
        public int ParcelaAtual { get; private set; }
        public bool Parcelado { get; private set; }
        public decimal ValorParcela { get; private set; }

        private ParcelamentoVO() { }

        public static ParcelamentoVO Create(int quantidadeParcelas, int parcelaAtual, bool parcelado, decimal valorParcela)
        {
            return new ParcelamentoVO
            {
                QuantidadeParcelas = quantidadeParcelas,
                ParcelaAtual = parcelaAtual,
                Parcelado = parcelado,
                ValorParcela = valorParcela
            };
        }
    }
}