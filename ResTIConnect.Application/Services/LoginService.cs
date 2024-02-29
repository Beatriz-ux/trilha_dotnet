using Microsoft.Extensions.DependencyInjection;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Data.Auth.Interfaces;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services;


public class LoginService : ILoginService
{
    private readonly AppDbContext _context;
    private readonly IAuthService _authService;
    public LoginService(AppDbContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public string Login(NewLoginInputModel login)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        var token = "";
        if (usuario == null)
        {
            throw new Exception("Email ou senha inválidos.");
        }
        if(usuario.Email == "admin@admin.com"){
            token = _authService.GenerateJwtToken(usuario.Email, "admin");
        }
        else{
            token = _authService.GenerateJwtToken(usuario.Email, "user");
        }

        return token;
    }

}
