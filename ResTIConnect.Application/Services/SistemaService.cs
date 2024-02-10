using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
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
    public int Create(NewSistemaInputModel sistema)
    {
        var _sistema = new Sistemas
        {
            Descricao = sistema.Descricao,
            Tipo = sistema.Tipo,
            EnderecoEntrada = sistema.EnderecoEntrada,
            EnderecoSaida = sistema.EnderecoSaida,
            Protocolo = sistema.Protocolo,
            DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao,
            Status = sistema.Status
        };
        _context.Sistemas.Add(_sistema);
        _context.SaveChanges();
        return _sistema.SistemaId;
    }
    public void Delete(int id)
    {
        _context.Sistemas.Remove(GetByDbId(id));
        _context.SaveChanges();
    }
    private Sistemas GetByDbId(int id)
    {
        var _sistema = _context.Sistemas.Find(id);
        if (_sistema == null)
        {
            return null;
        }
        return _sistema;
    }
    public List<SistemaViewModel> GetAll()
    {
        var _sistemas = _context.Sistemas.Select(s => new SistemaViewModel
        {
            SistemaId = s.SistemaId,
            Descricao = s.Descricao,
            Tipo = s.Tipo,
            EnderecoEntrada = s.EnderecoEntrada,
            EnderecoSaida = s.EnderecoSaida,
            Protocolo = s.Protocolo,
            DataHoraInicioIntegracao = s.DataHoraInicioIntegracao,
            Status = s.Status
        }).ToList();
        return _sistemas;
    }
    public SistemaViewModel? GetById(int id)
    {
        var _sistema = GetByDbId(id);
        var SistemaViewModel = new SistemaViewModel
        {
            SistemaId = _sistema.SistemaId,
            Descricao = _sistema.Descricao,
            Tipo = _sistema.Tipo,
            EnderecoEntrada = _sistema.EnderecoEntrada,
            EnderecoSaida = _sistema.EnderecoSaida,
            Protocolo = _sistema.Protocolo,
            DataHoraInicioIntegracao = _sistema.DataHoraInicioIntegracao,
            Status = _sistema.Status
        };
        return SistemaViewModel;
    }
    public void Update(int id, NewSistemaInputModel sistema)
    {
        var _sistema = GetByDbId(id);
        _sistema.Descricao = sistema.Descricao;
        _sistema.Tipo = sistema.Tipo;
        _sistema.EnderecoEntrada = sistema.EnderecoEntrada;
        _sistema.EnderecoSaida = sistema.EnderecoSaida;
        _sistema.Protocolo = sistema.Protocolo;
        _sistema.DataHoraInicioIntegracao = sistema.DataHoraInicioIntegracao;
        _sistema.Status = sistema.Status;
        _context.Sistemas.Update(_sistema);
        _context.SaveChanges();
    }
}
