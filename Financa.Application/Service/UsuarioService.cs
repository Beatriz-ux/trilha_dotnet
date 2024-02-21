using Financa.Application.InputModels;
using Financa.Application.Services.Interfaces;
using Financa.Application.ViewModels;
using Financa.Core.Entities;
using Financa.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Financa.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public List<UsuarioViewModel> GetAll()
    {
        var usuariosView = _context.Usuarios
        .Select(usuario => GetById(usuario.IdUsuario))
        .ToList();

        return usuariosView;
    }

    public UsuarioViewModel GetById(int id)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.IdUsuario == id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }

        var usuarioViewModel = new UsuarioViewModel
        {
            IdUsuario = usuario.IdUsuario,
            NomeUsuario = usuario.NomeUsuario,
            EmailUsuario = usuario.EmailUsuario,
            SenhaUsuario = usuario.SenhaUsuario,
            IdConta = usuario.IdConta
        };

        return usuarioViewModel;
    }

    public int Create(NewUsuarioInputModel model)
    {
        var contaEncontrada = _context.Contas
            .FirstOrDefault(c => c.IdConta == model.IdConta);

        if (contaEncontrada == null){
            throw new Exception("Conta não encontrada");
        }
        var usuario = new Usuario
        {
            NomeUsuario = model.NomeUsuario,
            EmailUsuario = model.EmailUsuario,
            SenhaUsuario = model.SenhaUsuario,
            IdConta = model.IdConta,
            Conta = contaEncontrada
        };

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return usuario.IdUsuario;
    }

    public void Update(int id, NewUsuarioInputModel model)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.IdUsuario == id);
        var contaEncontrada = _context.Contas
            .FirstOrDefault(c => c.IdConta == model.IdConta);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        if (contaEncontrada == null)
        {
            throw new Exception("Conta não encontrada");
        }

        usuario.NomeUsuario = model.NomeUsuario;
        usuario.EmailUsuario = model.EmailUsuario;
        usuario.SenhaUsuario = model.SenhaUsuario;
        usuario.IdConta = model.IdConta;
        usuario.Conta = contaEncontrada;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.IdUsuario == id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
    }

}
