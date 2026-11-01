using Microsoft.AspNetCore.Mvc;
using Orcamento.Core.Enums;
using Orcamento.Core.ValueObjects;

namespace Orcamento.Api.Controllers
{
    public class CadastrarDespesaController : ControllerBase
    {

        [HttpPost("cadastrar-despesa")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult cadastrarDespesa([FromBody] CadastrarDespesaRequest request)
        {
            return Ok(new { mensagem = "Despesa cadastrada com sucesso." });
        }

    }


    public record CadastrarDespesaRequest(
        string Descricao,
        decimal Valor,
        DateTime Data,
        string Categoria,
        bool Parcelado,
        ParcelamentoRequest? Parcelamento,
        int Tipo


    );

    public record ParcelamentoRequest(
        int QuantidadeParcelas,
        int ParcelaAtual,
        bool Parcelado,
        decimal ValorParcela
    );
}