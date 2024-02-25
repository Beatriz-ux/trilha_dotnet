using Microsoft.EntityFrameworkCore;
using TechMed.Application.InputModels;
using TechMed.Application.Services.Interfaces;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Infra.Persistence;

namespace TechMed.Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly IMedicoService _medicoService;
    private readonly IPacienteService _pacienteService;
    private readonly TechMedContext _context;

    public AtendimentoService(TechMedContext context, IMedicoService medicoService,
        IPacienteService pacienteService)
    {
        _context = context;
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    public int Create(NewAtendimentoInputModel atendimento)
    {
        return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
    }

    public void Delete(int id)
    {
        var _atendimento = GetById(id);
        _context.Atendimentos.Remove(_atendimento);
        _context.SaveChanges();
    }

    public List<AtendimentoViewModel> GetAll()
    {
        var _atendimentos = _context.Atendimentos
            .Include(a => a.Medico)
            .Include(b => b.Paciente)
            .Select(m => new AtendimentoViewModel
        {
            AtendimentoId = m.AtendimentoId,
            DataHoraInicio = m.DataHoraInicio,
            DataHoraFim = m.DataHoraFim,
            SuspeitaInicial = m.SuspeitaInicial,
            Diagnostico = m.Diagnostico,
            Medico = m.Medico,
            Paciente = m.Paciente
        }).ToList();
        if (_atendimentos.Count == 0) throw new Exception("Nenhum atendimento cadastrado");
        return _atendimentos;
    }

    public Atendimento GetById(int id)
    {
        var _atendimento = _context.Atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
        if (_atendimento == null) throw new Exception("Atendimento não encontrado");
        return _atendimento;
    }

    public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
    {
        var _atendimentos = _context.Atendimentos.Where(m => m.Medico.MedicoId == medicoId).Select(m => new AtendimentoViewModel
        {
            AtendimentoId = m.AtendimentoId,
            DataHoraInicio = m.DataHoraInicio,
            DataHoraFim = m.DataHoraFim,
            SuspeitaInicial = m.SuspeitaInicial,
            Diagnostico = m.Diagnostico,
            Medico = _medicoService.GetById(m.Medico.MedicoId),
            Paciente = _pacienteService.GetById(m.Paciente.PacienteId)
        }).ToList();
        if (_atendimentos.Count == 0) throw new Exception("Nenhum atendimento cadastrado com esse médico");
        return _atendimentos;
    }

    public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
    {
        var _atendimentos = _context.Atendimentos.Where(m => m.Paciente.PacienteId == pacienteId).Select(m => new AtendimentoViewModel
        {
            AtendimentoId = m.AtendimentoId,
            DataHoraInicio = m.DataHoraInicio,
            DataHoraFim = m.DataHoraFim,
            SuspeitaInicial = m.SuspeitaInicial,
            Diagnostico = m.Diagnostico,
            Medico = _medicoService.GetById(m.Medico.MedicoId),
            Paciente = _pacienteService.GetById(m.Paciente.PacienteId)
        }).ToList();
        if (_atendimentos.Count == 0) throw new Exception("Nenhum atendimento cadastrado com esse paciente");
        return _atendimentos;
    }

    public void Update(int id, NewAtendimentoInputModel atendimento)
    {
        var _atendimento = GetById(id);

        _atendimento.DataHoraInicio = atendimento.DataHoraInicio;
        _atendimento.DataHoraFim = atendimento.DataHoraFim;
        _atendimento.SuspeitaInicial = atendimento.SuspeitaInicial;
        _atendimento.Diagnostico = atendimento.Diagnostico;
        _atendimento.MedicoId = atendimento.MedicoId;
        _atendimento.PacienteId = atendimento.PacienteId;

        _context.Atendimentos.Update(_atendimento);
        _context.SaveChanges();
    }
}