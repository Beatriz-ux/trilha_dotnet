using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;
using TechMed.Infra.Persistence;
using System.Data.Common;

namespace TechMed.Application.Services;


public class MedicoService : IMedicoService
{
    private int _nextMedicoId = 1;
    private int _nextAtendimentoId = 1;
    private readonly TechMedDbContext _context;
    public MedicoService(TechMedDbContext context)
    {
        _context = context;
    }

    private Medico GetByDbId(int id)
    {
        var _medico = _context.Medicos.Find(id);

        if (_medico is null)
            throw new MedicoNotFoundException();

        return _medico;
    }

    private Medico GetByDbCrm(string crm)
    {
        var _medico = _context.Medicos.Find(crm);

        if (_medico is null)
            throw new MedicoNotFoundException();

        return _medico;
    }

    public int Create(NewMedicoInputModel medico)
    {
        var newMedicoId = _nextMedicoId++;
        var _medico = new Medico
        {
            MedicoId = newMedicoId,
            Nome = medico.Nome,
            Cpf = medico.Cpf,
            Crm = medico.Crm,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.MinValue
        };
        _context.Medicos.Add(_medico);

        _context.SaveChanges();

        return _medico.MedicoId;
    }

    public void Delete(int id)
    {
        var _medico = GetByDbId(id);
        _medico.DeletedAt = DateTime.Now;
        _context.Medicos.Remove(_medico);

        _context.SaveChanges();
    }

    public List<MedicoViewModel> GetAll()
    {
        var _medico = _context.Medicos.Select(m => new MedicoViewModel
        {
            MedicoId = m.MedicoId,
            Nome = m.Nome,
            Cpf = m.Cpf,
            Crm = m.Crm
        }).ToList();

        return _medico;
    }

    public MedicoViewModel? GetById(int id)
    {
        var _medico = GetByDbId(id);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Nome = _medico.Nome,
            Cpf = _medico.Cpf,
            Crm = _medico.Crm

        };
        return MedicoViewModel;
    }

    public void Update(int id, NewMedicoInputModel medico)
    {
        var _medico = GetByDbId(id);
        _medico.UpdatedAt = DateTime.Now;

        _medico.Nome = medico.Nome;

        _context.Medicos.Update(_medico);

        _context.SaveChanges();
    }

    public MedicoViewModel? GetByCrm(string crm)
    {
        var _medico = GetByDbCrm(crm);

        var MedicoViewModel = new MedicoViewModel
        {
            MedicoId = _medico.MedicoId,
            Nome = _medico.Nome,
            Cpf = _medico.Cpf,
            Crm = _medico.Crm

        };
        return MedicoViewModel;
    }

    public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
    {
        var medico = _context.Medicos.Find(medicoId);
        if (medico == null)
        {
            // Lançar exceção se o médico não for encontrado
            throw new Exception("Médico não encontrado.");
        }

        var paciente = _context.Pacientes.Find(atendimento.PacienteId);
        if (paciente == null)
        {
            // Lançar exceção se o paciente não for encontrado
            throw new Exception("Paciente não encontrado.");
        }

        var newAtendimentoId = _nextAtendimentoId++;
        var novoAtendimento = new Atendimento
        {
            AtendimentoId = newAtendimentoId,
            DataHoraInicio = atendimento.DataHoraInicio,
            SuspeitaInicial = atendimento.SuspeitaInicial,
            DataHoraFim = atendimento.DataHoraFim,
            Diagnostico = atendimento.Diagnostico,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.MinValue,
            Medico = new Medico
            {
                MedicoId = medico.MedicoId,
                Nome = medico.Nome,
                Cpf = medico.Cpf,
                Crm = medico.Crm
            },
            Paciente = new Paciente
            {
                PacienteId = paciente.PacienteId,
                Nome = paciente.Nome,
                Cpf = paciente.Cpf,
                DataNascimento = paciente.DataNascimento,
            }
        };

        _context.Atendimentos.Add(novoAtendimento);
        _context.SaveChanges();

        return novoAtendimento.AtendimentoId;
    }
}
