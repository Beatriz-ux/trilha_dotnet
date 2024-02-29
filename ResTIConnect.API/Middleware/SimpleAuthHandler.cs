using System.Text;
using ResTIConnect.Infra.Data.Auth.Interfaces;

namespace ResTIConnect.API.Middleware;

public class SimpleAuthHandler
{
    private readonly RequestDelegate _next;
    public SimpleAuthHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authService = context.RequestServices.GetRequiredService<IAuthService>();
        if(context.Request.Path.StartsWithSegments("/api/login")){
            await _next(context);
            return;
        }
        //verificar se existe a chave Authorization no Header da requisição
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            //context.Response.Headers.Add("WWW-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing");
            return;
        }

        //verificar se o valor da chave Authorization é igual
        //ao username e password esperados "Basic username:password"
        var header = context.Request.Headers["Authorization"].ToString();
        var role = authService.GetRoleFromToken(header);
        // var encondedUsernamePassword = header.Substring(6);
        // var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));
        // string[] usernamePassword = decodedUsernamePassword.Split(":");
        // var email = usernamePassword[0];
        // var role = usernamePassword[1];
        

        if (role == "admin")
        {
            await _next(context);
            return;
        }
        /* “Perfis”, “Sistemas”, “Eventos”*/
        if (context.Request.Path.StartsWithSegments("/api/Perfil") && role != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Você não tem permissão para acessar este recurso");
            return;

        }
        if (context.Request.Path.StartsWithSegments("/api/sistemas") && role != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Você não tem permissão para acessar este recurso");
            return;

        }
        if (context.Request.Path.StartsWithSegments("/api/evento") && role != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Você não tem permissão para acessar este recurso");
            return;

        }
        

        await _next(context);
    }
}
