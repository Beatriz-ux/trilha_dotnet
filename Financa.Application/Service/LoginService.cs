using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Infrastructure;

namespace Financa.Application;

public class LoginService: ILoginService
{
    private readonly AppDbContext _context;
    public LoginService(AppDbContext context)
    {
        _context = context;
    }

    public string Login(NewLoginInputModel login)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.EmailUsuario == login.Email && u.SenhaUsuario == login.Senha);
        if (usuario == null)
        {
            throw new Exception("Email ou senha inválidos!");
        }
        return "Login efetuado com sucesso!";
    }

}
