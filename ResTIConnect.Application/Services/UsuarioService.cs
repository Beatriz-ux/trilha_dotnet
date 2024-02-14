using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;
    private readonly IEnderecoService _enderecoService;

    public UsuarioService(AppDbContext context, IEnderecoService enderecoService)
    {
        _context = context;
        _enderecoService = enderecoService;
    }

    public List<UsuarioViewModel> GetAll()
    {
        var usuarios = _context.Usuarios.ToList();
        return usuarios.Select(u => new UsuarioViewModel
        {
            UsuarioId = u.UsuarioId,
            Nome = u.Nome,
            Email = u.Email,
            Endereco = _enderecoService.GetByIdWithoutUsers(u.EnderecoId) ?? new EnderecoUserViewModel(),
            SistemasId = u.Sistemas.Select(s => s.SistemaId).ToList()
        }).ToList();
    }

    public UsuarioViewModel? GetById(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        return new UsuarioViewModel
        {
            UsuarioId = usuario.UsuarioId,
            Nome = usuario.Nome,
            Email = usuario.Email,
            
            Endereco = _enderecoService.GetByIdWithoutUsers(usuario.EnderecoId) ?? new EnderecoUserViewModel(),
            SistemasId = usuario.Sistemas != null ? usuario.Sistemas.Select(s => s.SistemaId).ToList() : new List<int>()
        };
    }

    public int Create(NewUsuarioInputModel usuario)
    {
        var endereco = _context.Enderecos.Find(usuario.EnderecoId);
        if (endereco == null)
        {
            throw new Exception("Endereço não encontrado");
        }
        var novoUsuario = new Usuarios
        {
            Nome = usuario.Nome,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Telefone = usuario.Telefone,
            Endereco = endereco,
            EnderecoId = endereco.EnderecoId,
            Sistemas = usuario.SistemasId.Select(id => new Sistema { SistemaId = id }).ToList()
        };
        if (endereco.Usuarios == null)
        {
            endereco.Usuarios = new List<Usuarios>();
        }
        endereco.Usuarios.Add(novoUsuario);
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();
        return novoUsuario.UsuarioId;
    }

    public void Update(int id, NewUsuarioInputModel usuario)
    {
        var usuarioAtual = _context.Usuarios.Find(id);
        if (usuarioAtual == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        var endereco = _context.Enderecos.Find(usuario.EnderecoId);
        if (endereco == null)
        {
            throw new Exception("Endereço não encontrado");
        }
        usuarioAtual.Nome = usuario.Nome;
        usuarioAtual.Email = usuario.Email;
        usuarioAtual.Senha = usuario.Senha;
        usuarioAtual.Telefone = usuario.Telefone;
        usuarioAtual.Endereco = endereco;
        usuarioAtual.EnderecoId = endereco.EnderecoId;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
    }
}
