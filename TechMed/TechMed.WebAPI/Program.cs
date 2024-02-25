using Microsoft.EntityFrameworkCore;
using TechMed.Application.Services;
using TechMed.Application.Services.Interfaces;
using TechMed.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TechMedContext>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IExameService, ExameService>();

builder.Services.AddDbContext<TechMedContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TechMedDb");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
