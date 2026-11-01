using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

namespace Orcamento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportacoesController : ControllerBase
    {
        [HttpPost("excel")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ImportarExcel(IFormFile arquivo)
        {
            if (arquivo is null || arquivo.Length == 0)
            {
                return BadRequest(new { mensagem = "Selecione um arquivo válido." });
            }

            var extensao = Path.GetExtension(arquivo.FileName);
            if (!string.Equals(extensao, ".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { mensagem = "Formato de arquivo inválido. Por favor, envie um arquivo Excel (.xlsx)." });
            }

            try
            {
                using var stream = arquivo.OpenReadStream();
                using var workbook = new XLWorkbook(stream);

                var planilha = workbook.Worksheets
                    .FirstOrDefault(x => x.Name == "Lançamentos");

                if (planilha is null)
                {
                    return BadRequest(new { mensagem = "A planilha 'Lançamentos' não foi encontrada no arquivo Excel." });
                }

                var ultimaLinnha = planilha.LastRowUsed()?.RowNumber() ?? 1;
                var totalRegistros = Math.Max(0, ultimaLinnha - 1); // Subtrai 1 para ignorar o cabeçalho

                return Ok(new
                {
                    mensagem = "Arquivo importado com sucesso.",
                    arquivo = Path.GetFileName(arquivo.FileName),
                    planilha = planilha.Name,
                    totalRegistros = totalRegistros
                });
            }
            catch (Exception ex)
            {
                // Log do erro (ex.Message) se necessário
                return BadRequest(new { mensagem = $"Ocorreu um erro ao importar o arquivo: {ex.Message}" });
            }
        }


    }
}