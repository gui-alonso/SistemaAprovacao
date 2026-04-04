using Microsoft.AspNetCore.Mvc;
using SistemaAprovacao.Application.DTOs;
using SistemaAprovacao.Application.Services;

namespace SistemaAprovacao.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SolicitacaoController : ControllerBase
{
    private readonly SolicitacaoAppService _service;

    public SolicitacaoController(SolicitacaoAppService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CriarSolicitacaoRequest request)
    {
        var id = await _service.CriarNovaSolicitacao(request);
        
        // Retorna 200 OK com o ID da nova solicitação criada na memória
        return Ok(new { Message = "Solicitação criada com sucesso!", Id = id });
    }
}