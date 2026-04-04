using SistemaAprovacao.Domain.Enums;

namespace SistemaAprovacao.Domain.Entities;

public class Solicitacao
{
    // O set é private para que ninguém mude o ID ou Status sem passar pelos métodos
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusSolicitacao Status { get; private set; }
    public string? ObservacaoAnalise { get; private set; }

    // Construtor para criar uma nova solicitação
    public Solicitacao(string titulo, string descricao, decimal valor)
    {
        if (string.IsNullOrWhiteSpace(titulo)) throw new ArgumentException("Título é obrigatório");
        if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero");

        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        Valor = valor;
        DataCriacao = DateTime.UtcNow;
        Status = StatusSolicitacao.Pendente;
    }

    // Comportamento: A regra de aprovação mora aqui!
    public void Aprovar(string observacao)
    {
        if (Status != StatusSolicitacao.Pendente)
            throw new InvalidOperationException("Apenas solicitações pendentes podem ser aprovadas.");

        Status = StatusSolicitacao.Aprovado;
        ObservacaoAnalise = observacao;
    }

    public void Rejeitar(string motivo)
    {
        if (Status != StatusSolicitacao.Pendente)
            throw new InvalidOperationException("Apenas solicitações pendentes podem ser rejeitadas.");

        Status = StatusSolicitacao.Rejeitado;
        ObservacaoAnalise = motivo;
    }
}