using DOTNET_P002;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/beatriz", () => Beatriz.View());
app.MapGet("/brendom/", () => Brendom.View());
app.MapGet("/alberto", () => Alberto.View());
app.MapGet("/alessandro", () => Alessandro.View());

app.Run();
