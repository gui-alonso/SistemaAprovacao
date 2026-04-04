using SistemaAprovacao.Application.DTOs;
using SistemaAprovacao.Domain.Entities;
using SistemaAprovacao.Domain.Interfaces;

namespace SistemaAprovacao.Application.Services;

public class SolicitacaoAppService
{
    private readonly ISolicitacaoRepository _repository;

    public SolicitacaoAppService(ISolicitacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CriarNovaSolicitacao(CriarSolicitacaoRequest request)
    {
        // 1. Cria a entidade usando a lógica do Domínio
        var novaSolicitacao = new Solicitacao(request.Titulo, request.Descricao, request.Valor);

        // 2. Manda o repositório salvar (aqui a mágica da interface acontece)
        await _repository.AdicionarAsync(novaSolicitacao);

        return novaSolicitacao.Id;
    }
}