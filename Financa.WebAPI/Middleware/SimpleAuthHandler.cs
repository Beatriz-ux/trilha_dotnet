using System.Text;

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
        var encondedUsernamePassword = header.Substring(6);
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encondedUsernamePassword));
        string[] usernamePassword = decodedUsernamePassword.Split(":");
        var email = usernamePassword[0];
        var role = usernamePassword[1];

        if (email == "admin" && role == "admin")
        {
            await _next(context);
            return;
        }
        if (email != "admin" || role != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }

        await _next(context);
    }
}
