namespace SistemaAprovacao.Application.DTOs;

public record CriarSolicitacaoRequest(string Titulo, string Descricao, decimal Valor);