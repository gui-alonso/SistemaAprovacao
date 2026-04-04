using SistemaAprovacao.Domain.Entities;

namespace SistemaAprovacao.Domain.Interfaces;

public interface ISolicitacaoRepository
{
    // O contrato diz O QUE o sistema faz, não COMO ele faz.
    Task<Solicitacao?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Solicitacao>> ObterTodasAsync();
    Task AdicionarAsync(Solicitacao solicitacao);
    Task AtualizarAsync(Solicitacao solicitacao);
}