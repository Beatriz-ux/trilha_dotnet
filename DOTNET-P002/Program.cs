using DOTNET_P002;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/alberto", () => Alberto.View());

app.Run();
