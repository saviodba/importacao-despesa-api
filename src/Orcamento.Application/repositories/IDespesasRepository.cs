using Orcamento.Core.Entities;

namespace Orcamento.Application.repositories
{
    public interface IDespesasRepository
    {
        Task AddDespesa(Lancamento request);
        Task<IEnumerable<Lancamento>> GetDespesas();
        Task<Lancamento?> GetDespesaById(int id);
        Task UpdateDespesa(int id, Lancamento request);
        Task DeleteDespesa(int id);
    }
}