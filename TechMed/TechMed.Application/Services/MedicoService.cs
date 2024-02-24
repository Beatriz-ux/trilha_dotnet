using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infra.Persistence;

namespace TechMed.Application.Services;

public class MedicoService : IMedicoService
{
  private readonly TechMedContext _context;
  public MedicoService(TechMedContext context)
  {
    _context = context;
  }

  public int Create(NewMedicoInputModel medico)
  {
    var _medico = new Medico
    {
      Nome = medico.Nome,
      Crm = medico.Crm,
      Cpf = medico.Cpf
    };
    _context.Medicos.Add(_medico);
    _context.SaveChanges();
    return _medico.MedicoId;
  }
  public void Delete(int id) 
  {
    var _medico = GetById(id);
    _context.Medicos.Remove(_medico);
    _context.SaveChanges();
  }
  public List<MedicoViewModel> GetAll()
  {
    var _medicos = _context.Medicos.Select(m => new MedicoViewModel
    {
      MedicoId = m.MedicoId,
      Nome = m.Nome,
      Cpf = m.Cpf,
      Crm = m.Crm
    }).ToList();
    if(_medicos.Count == 0) throw new Exception("Nenhum médico cadastrado");
    return _medicos;
  }
  public Medico GetById(int id)
  {
    var _medico = _context.Medicos.FirstOrDefault(m => m.MedicoId == id);
    if(_medico == null) throw new Exception("Médico não encontrado");
    return _medico;
  }
  public MedicoViewModel? GetByCrm(string crm)
  {
    var _medico = _context.Medicos.FirstOrDefault(m => m.Crm == crm);
    if(_medico == null) throw new Exception("Médico não encontrado");
    var _medicoViewModel = new MedicoViewModel
    {
      MedicoId = _medico.MedicoId,
      Nome = _medico.Nome,
      Cpf = _medico.Cpf,
      Crm = _medico.Crm
    };
    return _medicoViewModel;
  }
  public void Update(int id, NewMedicoInputModel medico)
  {
    var _medico = GetById(id);
    
    _medico.Nome = medico.Nome;
    _medico.Cpf = medico.Cpf;
    _medico.Crm = medico.Crm;
    
    _context.Medicos.Update(_medico);
    _context.SaveChanges();
  }
  public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
  {
    var _medico = GetById(medicoId);
    
    var _paciente = _context.Pacientes.FirstOrDefault(p => p.PacienteId == atendimento.PacienteId);
    if (_paciente == null) throw new Exception("Paciente não encontrado");
    
    var _atendimento = new Atendimento
    {
      DataHoraInicio = atendimento.DataHoraInicio,
      DataHoraFim = atendimento.DataHoraFim,
      SuspeitaInicial = atendimento.SuspeitaInicial,
      Diagnostico = atendimento.Diagnostico,
      Medico = _medico,
      Paciente = _paciente,
    };
    _medico.Atendimentos?.Add(_atendimento);
    _paciente.Atendimentos?.Add(_atendimento);
    _context.Atendimentos.Add(_atendimento);
    _context.SaveChanges();
    return _atendimento.AtendimentoId;
  }

}