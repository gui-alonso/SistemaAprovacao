using SistemaAprovacao.Application.Services;
using SistemaAprovacao.Domain.Interfaces;
using SistemaAprovacao.Infrastructure.Repositories;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // --- REGISTRO DAS DEPENDÊNCIAS ---
        // Aqui dizemos ao .NET como resolver as interfaces
        builder.Services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
        builder.Services.AddScoped<SolicitacaoAppService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.Run();
    }
}