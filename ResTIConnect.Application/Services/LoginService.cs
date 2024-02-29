using Microsoft.Extensions.DependencyInjection;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services;


public class LoginService : ILoginService
{
    private readonly AppDbContext _context;
    public LoginService(AppDbContext context)
    {
        _context = context;
    }

    public int Login(NewLoginInputModel login)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        return usuario.UsuarioId;
    }

}
