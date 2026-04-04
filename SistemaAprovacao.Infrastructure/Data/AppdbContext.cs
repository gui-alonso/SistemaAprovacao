using Microsoft.EntityFrameworkCore;
using SistemaAprovacao.Domain.Entities;

namespace SistemaAprovacao.Infrastructure.Data; // <--- Confira este Namespace

public class AppDbContext : DbContext // <--- Precisa ser PUBLIC
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Solicitacao> Solicitacoes => Set<Solicitacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}