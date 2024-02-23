using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infra.Persistence;

namespace TechMed.Application.Services;

public class ExameService : IExameService
{
    private readonly TechMedContext _context;
    private readonly IAtendimentoService _atendimentoService;
    
    public ExameService(TechMedContext context, IAtendimentoService atendimentoService)
    {
        _context = context;
        _atendimentoService = atendimentoService;
    }

    public int Create(NewExameInputModel exame)
    {
        var _atendimento = _atendimentoService.GetById(exame.AtendimentoId);
        var _exame = new Exame
        {
            Nome = exame.Nome,
            Valor = exame.Valor,
            Local = exame.Local,
            DataHora = exame.DataHora,
            ResultadoDescricao = exame.ResultadoDescricao,
            Atendimento = _atendimento
        };
        _context.Exames.Add(_exame);
        _context.SaveChanges();
        return _exame.ExameId;
    }
    public void Delete(int id)
    {
        var _exame = GetById(id);
        _context.Exames.Remove(_exame);
        _context.SaveChanges();
    }
    public List<ExameViewModel> GetAll()
    {
        var _exames = _context.Exames.Select(m => new ExameViewModel
        {
            ExameId = m.ExameId,
            Nome = m.Nome,
            Valor = m.Valor,
            Local = m.Local,
            DataHora = m.DataHora,
            ResultadoDescricao = m.ResultadoDescricao,
            Atendimento = _atendimentoService.GetById(m.AtendimentoId)
        }).ToList();
        if (_exames.Count == 0) throw new Exception("Nenhum exame cadastrado");
        return _exames;
    }

    public Exame GetById(int id)
    {
        var _exame = _context.Exames.FirstOrDefault(m => m.ExameId == id);
        if(_exame == null) throw new Exception("Exame não encontrado");
        return _exame;
    }
    public void Update(int id, NewExameInputModel exame)
    {
        var _exame = GetById(id);
        
        _exame.Nome = exame.Nome;
        _exame.Valor = exame.Valor;
        _exame.Local = exame.Local;
        _exame.DataHora = exame.DataHora;
        _exame.ResultadoDescricao = exame.ResultadoDescricao;
        _exame.AtendimentoId = exame.AtendimentoId;
        
        _context.Exames.Update(_exame);
        _context.SaveChanges();
    }
}