using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Infrastructure;
using Financa.Infrastructure.Auth.Interface;
using Microsoft.AspNetCore.Http;

namespace Financa.Application;

public class LoginService: ILoginService
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
        string _token = "";
        var usuario = _context.Usuarios.FirstOrDefault(u => u.EmailUsuario == login.Email && u.SenhaUsuario == login.Senha);
        if (usuario == null)
        {
            throw new Exception("Email ou senha inválidos!");
        }
        if(usuario.EmailUsuario == "admin"){
            _token = _authService.GenerateJwtToken(usuario.EmailUsuario, "admin");
        }
        else{
            _token = _authService.GenerateJwtToken(usuario.EmailUsuario, "user");
        }
        
        return _token;
    }
}
