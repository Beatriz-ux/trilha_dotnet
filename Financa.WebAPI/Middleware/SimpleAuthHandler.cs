using System.Text;
using Financa.Application.Auth;

namespace Financa.WebAPI.Middleware;

public class SimpleAuthHandler
{
    private readonly RequestDelegate _next;
    public SimpleAuthHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authService = context.RequestServices.GetService<AuthService>();
        if(context.Request.Path.StartsWithSegments("/api/login"))
        {
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
        var header = context.Request.Headers["Authorization"].ToString();
        //ao username e password esperados "Basic username:password"
        // var encondedUsernamePassword = header.Substring(6);
        // var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));
        // string[] usernamePassword = decodedUsernamePassword.Split(":");
        // var email = usernamePassword[0];
        var role = authService.GetRoleFromToken(header);

        if (role == "admin")
        {
            await _next(context);
            return;
        }

        if (context.Request.Path.StartsWithSegments("/api/Conta") && role != "admin")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden");
            return;
        }

        if (context.Request.Path.StartsWithSegments("/api/Transacao") && role != "admin")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden");
            return;
        }

        if (context.Request.Path.StartsWithSegments("/api/Usuario") && role != "admin")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Forbidden");
            return;
        }

        await _next(context);
    }
}
