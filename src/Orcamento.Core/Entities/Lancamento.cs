using Orcamento.Core.Enums;
using Orcamento.Core.ValueObjects;

namespace Orcamento.Core.Entities
{
    public class Lancamento
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public ParcelamentoVO? Parcelamento { get; private set; }
        public string Categoria { get; private set; }
        public Situacao Situacao { get; private set; } = Situacao.Aberto;
        public TipoDespesa Tipo { get; private set; }

        private Lancamento() { }

        public Lancamento create(string descricao, decimal valor, DateTime data, string categoria, Situacao situacao, TipoDespesa tipo)
        {
            return new Lancamento
            {
                Descricao = descricao,
                Valor = valor,
                Data = data,
                Categoria = categoria,
                Situacao = situacao,
                Tipo = tipo
            };
        }

        public void DefinirComoPago()
        {
            Situacao = Situacao.Pago;
        }

        public void AdicionarParcelamento(ParcelamentoVO parcelamento)
        {
            Parcelamento = parcelamento;
        }
    }
}