using ResTIConnect.Application.Services;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();
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
