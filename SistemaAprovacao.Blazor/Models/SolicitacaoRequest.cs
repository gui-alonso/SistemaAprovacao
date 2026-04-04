namespace SistemaAprovacao.Blazor.Models;

public class SolicitacaoRequest
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}