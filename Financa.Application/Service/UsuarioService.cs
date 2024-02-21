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
            .Select(u => new UsuarioViewModel
            {
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                EmailUsuario = u.EmailUsuario,
                IdConta = u.Conta.IdConta
            })
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
            IdConta = usuario.IdConta
        };

        return usuarioViewModel;
    }

    public int Create(NewUsuarioInputModel model)
    {
        var usuario = new Usuario
        {
            NomeUsuario = model.NomeUsuario,
            EmailUsuario = model.EmailUsuario,
            SenhaUsuario = model.SenhaUsuario,
            Conta = new Conta
            {
                TipoConta = model.Conta.TipoConta,
                SaldoConta = model.Conta.SaldoConta

            }
        };

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return usuario.Conta.IdConta;
    }

    public void Update(int id, NewUsuarioInputModel model)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.IdUsuario == id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        var contaEncontrada = _context.Contas
            .FirstOrDefault(c => c.IdConta == usuario.IdConta);

        
        if (contaEncontrada == null)
        {
            throw new Exception("Conta não encontrada");
        }

        usuario.NomeUsuario = model.NomeUsuario;
        usuario.EmailUsuario = model.EmailUsuario;
        usuario.SenhaUsuario = model.SenhaUsuario;
        // usuario.IdConta = model.Conta.IdConta;
        // usuario.Conta = contaEncontrada;

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
