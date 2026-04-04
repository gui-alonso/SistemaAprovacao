using Microsoft.EntityFrameworkCore;
using SistemaAprovacao.Application.Services;
using SistemaAprovacao.Domain.Interfaces;
using SistemaAprovacao.Infrastructure.Data;
using SistemaAprovacao.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --- CONFIGURAÇÃO DO BANCO DE DADOS (SQL SERVER / DOCKER) ---
// 1. Buscamos a string de conexão que está no seu appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registramos o DbContext no container de Injeção de Dependência
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- REGISTRO DAS DEPENDÊNCIAS DO SISTEMA ---
// Agora o Repositório vai receber o AppDbContext automaticamente via construtor
builder.Services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
builder.Services.AddScoped<SolicitacaoAppService>();

// Configurações padrão da Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Pipeline de Requisições (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();