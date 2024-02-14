using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Infra.Data.Models;

namespace ResTIConnect.Application.Services;

public class SistemaService : ISistemaService
{
    private readonly AppDbContext _context;
    public SistemaService(AppDbContext context)
    {
        _context = context;
    }
    public List<SistemaViewModel> GetAll()
    {
        var sistemas = _context.Sistemas.ToList();
        return sistemas.Select(s => GetById(s.SistemaId) ?? new SistemaViewModel { UsuariosId = new List<int>() }).ToList();
    }
    public SistemaViewModel? GetById(int id)
    {
        var sistema = _context.Sistemas.Include(s => s.Usuarios).FirstOrDefault(s => s.SistemaId == id);
        if (sistema == null)
        {
            throw new Exception("Sistema não encontrado");
        }

        return new SistemaViewModel
        {
            SistemaId = sistema.SistemaId,
            Descricao = sistema.Descricao,
            Tipo = sistema.Tipo,
            EnderecoEntrada = sistema.EnderecoEntrada,
            EnderecoSaida = sistema.EnderecoSaida,
            Protocolo = sistema.Protocolo,
            DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
            Status = sistema.Status,

            UsuariosId = sistema.Usuarios != null ? sistema.Usuarios.Select(u => u.UsuarioId).ToList() : new List<int>()
        };
    }
    public int Create(NewSistemaInputModel sistema)
    {
        var _sistema = new Sistema
        {
            Descricao = sistema.Descricao,
            Tipo = sistema.Tipo,
            EnderecoEntrada = sistema.EnderecoEntrada,
            EnderecoSaida = sistema.EnderecoSaida,
            Protocolo = sistema.Protocolo,
            DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
            Status = sistema.Status,
            Usuarios = sistema.UsuariosId.Select(id => new Usuarios { UsuarioId = id }).ToList()
        };
        _context.Sistemas.Add(_sistema);
        _context.SaveChanges();
        return _sistema.SistemaId;
    }
    public void Delete(int id)
    {
        var sistema = _context.Sistemas.Include(e => e.Usuarios).FirstOrDefault(s => s.SistemaId == id);
        if (sistema == null)
        {
            throw new Exception("Sistema não encontrado");
        }
        if (sistema.Usuarios != null && sistema.Usuarios.Count > 0)
        {
            throw new Exception("Sistema não pode ser excluído, pois possui usuários associados");
        }
        _context.Sistemas.Remove(sistema);
        _context.SaveChanges();
    }
    public void Update(int id, NewSistemaInputModel sistema)
    {
        var _sistema = _context.Sistemas.Find(id);
        if (_sistema == null)
        {
            throw new Exception("Sistema não encontrado");
        }
        _sistema.Descricao = sistema.Descricao;
        _sistema.Tipo = sistema.Tipo;
        _sistema.EnderecoEntrada = sistema.EnderecoEntrada;
        _sistema.EnderecoSaida = sistema.EnderecoSaida;
        _sistema.Protocolo = sistema.Protocolo;
        _sistema.DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao;
        _sistema.Status = sistema.Status;
        _context.SaveChanges();
    }
}
