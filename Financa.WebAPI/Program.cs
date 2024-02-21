using Financa.Application.Services;
using Financa.Application.Services.Interfaces;
using Financa.Infrastructure;
using Financa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IObjetivoService, ObjetivoService>();
builder.Services.AddScoped<IInvestimentoService, InvestimentoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("FinancaDb");

        var serverVersion = ServerVersion.AutoDetect(connectionString);

        options.UseMySql(connectionString, serverVersion);
    });
// builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
