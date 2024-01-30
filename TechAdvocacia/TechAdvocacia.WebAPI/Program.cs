using Microsoft.EntityFrameworkCore;
using TechAdvocacia.Core.Entities;
using TechAdvocacia.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TechAdvocaciaDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("TechAdvocacia");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

      options.UseMySql(connectionString, serverVersion);
});

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
