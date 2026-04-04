using SistemaAprovacao.Domain.Entities;
using SistemaAprovacao.Domain.Interfaces;

namespace SistemaAprovacao.Infrastructure.Repositories;

public class SolicitacaoRepository : ISolicitacaoRepository
{
    // Simulando o banco de dados com uma lista em memória
    private static readonly List<Solicitacao> _db = new();

    public Task AdicionarAsync(Solicitacao solicitacao)
    {
        _db.Add(solicitacao);
        return Task.CompletedTask;
    }

    public Task<Solicitacao?> ObterPorIdAsync(Guid id)
    {
        return Task.FromResult(_db.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<Solicitacao>> ObterTodasAsync()
    {
        return Task.FromResult(_db.AsEnumerable());
    }

    public Task AtualizarAsync(Solicitacao solicitacao)
    {
        var index = _db.FindIndex(x => x.Id == solicitacao.Id);
        if (index != -1) _db[index] = solicitacao;
        return Task.CompletedTask;
    }
}