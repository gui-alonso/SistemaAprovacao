using Microsoft.EntityFrameworkCore;
using SistemaAprovacao.Application.Services;
using SistemaAprovacao.Domain.Interfaces;
using SistemaAprovacao.Infrastructure.Data;
using SistemaAprovacao.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Banco de Dados (SQL Server via Docker)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Injeção de Dependência
builder.Services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
builder.Services.AddScoped<SolicitacaoAppService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configuração de CORS (Abertura para o Blazor)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
        policy.WithOrigins("http://localhost:5281", "https://localhost:5281") // Troque pelas portas do SEU Blazor
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// --- ORDEM DO PIPELINE (IMPORTANTE) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// O CORS deve vir ANTES de Authorization e MapControllers
app.UseCors("AllowBlazor");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();