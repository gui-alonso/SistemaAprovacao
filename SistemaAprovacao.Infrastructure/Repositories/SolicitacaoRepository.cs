using Microsoft.EntityFrameworkCore;
using SistemaAprovacao.Domain.Entities;
using SistemaAprovacao.Domain.Interfaces;
using SistemaAprovacao.Infrastructure.Data;

namespace SistemaAprovacao.Infrastructure.Repositories;

public class SolicitacaoRepository : ISolicitacaoRepository
{
    private readonly AppDbContext _context;

    public SolicitacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Solicitacao solicitacao)
    {
        await _context.Solicitacoes.AddAsync(solicitacao);
        
        // ESTA LINHA É O "COMMIT": Ela envia o dado para o Docker
        await _context.SaveChangesAsync(); 
    }

    public async Task<Solicitacao?> ObterPorIdAsync(Guid id)
    {
        return await _context.Solicitacoes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Solicitacao>> ObterTodasAsync()
    {
        return await _context.Solicitacoes.ToListAsync();
    }

    public async Task AtualizarAsync(Solicitacao solicitacao)
    {
        _context.Solicitacoes.Update(solicitacao);
        await _context.SaveChangesAsync();
    }
}